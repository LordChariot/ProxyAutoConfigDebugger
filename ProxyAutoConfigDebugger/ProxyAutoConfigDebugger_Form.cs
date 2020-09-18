using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using Microsoft.JScript.Vsa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Permissions;
using System.Windows.Forms;

namespace ProxyAutoConfigDebugger
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class ProxyAutoConfigDebugger_Form : Form
    {
        //Obsolete, but works
        private static readonly VsaEngine Engine = VsaEngine.CreateEngine();

        //for editor
        ProxyAutoConfigDebugger_FindAndReplace_Form _findForm = new ProxyAutoConfigDebugger_FindAndReplace_Form();
        FileSyntaxModeProvider fileSyntaxModeProvider;

        public ProxyAutoConfigDebugger_Form()
        {
            InitializeComponent();

        }

        #region Form Events   
        //form
        private void ProxyAutoConfigDebugger_Form_Load(object sender, EventArgs e)
        {
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            toolStripMenuItem_AutoIP.Checked = Properties.Settings.Default.AutoIPChecked;
            ToolStripMenuItem_AutoIP_CheckedChanged(toolStripMenuItem_AutoIP, null);
            toolStripMenuItem_FindProxyForURLEx.Checked = Properties.Settings.Default.FindProxyForURLExChecked;
            toolStripComboBox_Uri.ComboBox.Items.AddRange(Properties.Settings.Default.UriList.OfType<string>().ToArray());

            //initialize the editor control
            fileSyntaxModeProvider = new FileSyntaxModeProvider($"{AppDomain.CurrentDomain.BaseDirectory}");
            HighlightingManager.Manager.AddSyntaxModeFileProvider(fileSyntaxModeProvider);

            //put PAC into text editor. if doesn't exist, use default.
            textEditorControl_Editor.Text = (String.IsNullOrEmpty(Properties.Settings.Default.PAC_JavaScript)) ? Properties.Resources.PAC_JavaScript : Properties.Settings.Default.PAC_JavaScript;

            toolStripMenuItem_ToggleGlyphs.Checked = Properties.Settings.Default.ToggleGlyphs;
            ToolStripMenuItem_ToggleGlyphs_Click(toolStripMenuItem_ToggleGlyphs, null);
            toolStripMenuItem_ToggleColor.Checked = Properties.Settings.Default.ToggleColor;
            ToolStripMenuItem_ToggleColor_Click(toolStripMenuItem_ToggleColor, null);

            //initialize webBrowser_Results window
            InitializeWebBrowser_Results();

        }

        private void ProxyAutoConfigDebugger_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.UriList.Clear();
            Properties.Settings.Default.UriList.AddRange(toolStripComboBox_Uri.Items.OfType<string>().ToArray());
            Properties.Settings.Default.Save();
        }

        //menuStrip_Form
        private void ToolStripComboBox_Uri_TextChanged(object sender, EventArgs e)
        {
            //only accept http, https, ftp
            if (Uri.TryCreate(toolStripComboBox_Uri.Text, UriKind.Absolute, out Uri uri) &&
                (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeFtp))
            {
                toolStripComboBox_Uri.BackColor = SystemColors.Window;
                toolStripMenuItem_Test.Enabled = true;
                return;
            }
            else
            {
                toolStripComboBox_Uri.BackColor = SystemColors.Info;
                toolStripMenuItem_Test.Enabled = false;
                return;
            }
        }
        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            using (AboutBox_Form aboutBox_Form = new AboutBox_Form())
            {
                aboutBox_Form.ShowDialog();
            }
        }
        private void ToolStripMenuItem_AutoIP_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender as ToolStripMenuItem;
            if (toolStripMenuItem.Checked)
            {
                toolStripMenuItem.Image = Properties.Resources.CheckBoxChecked_16x;
            }
            else
            {
                toolStripMenuItem.Image = Properties.Resources.CheckBoxUnchecked_16x;
            }
            toolStripTextBox_AutoIP.ReadOnly = toolStripMenuItem.Checked;
            Properties.Settings.Default.AutoIPChecked = toolStripMenuItem.Checked;
        }
        private void ToolStripMenuItem_FindProxyForURLEx_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender as ToolStripMenuItem;
            if (toolStripMenuItem.Checked)
            {
                toolStripMenuItem.Image = Properties.Resources.CheckBoxChecked_16x;
            }
            else
            {
                toolStripMenuItem.Image = Properties.Resources.CheckBoxUnchecked_16x;
            }
            Properties.Settings.Default.FindProxyForURLExChecked = toolStripMenuItem.Checked;
        }
        private void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            //for some reason mouseovers don't highlight menu items when focus is on the URI combobox, dunno why.
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender as ToolStripMenuItem;
            toolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            toolStripStatusLabel_Form.Text = $"{toolStripMenuItem.ToolTipText}";
        }
        private void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender as ToolStripMenuItem;
            toolStripMenuItem.BackColor = SystemColors.Control;
            toolStripStatusLabel_Form.Text = $"";
        }
        private void ToolStripMenuItem_Test_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel_Form.Text = $"Testing: {toolStripComboBox_Uri.Text}";
            if (string.IsNullOrEmpty(toolStripComboBox_Uri.Text)) return;

            GetProxyForUrlUsingPacFile(toolStripComboBox_Uri.Text);

            if (!toolStripComboBox_Uri.ComboBox.Items.Contains(toolStripComboBox_Uri.Text))
                toolStripComboBox_Uri.ComboBox.Items.Add(toolStripComboBox_Uri.Text);
        }

        //menuStrip_Editor
        private void TextEditorControl_Editor_TextChanged(object sender, EventArgs e)
        {
            TextEditorControl textEditorControl = (TextEditorControl)sender as TextEditorControl;
            toolStripStatusLabel_Form.Text = string.Empty;
            //testcompile here
            if (!CompileJavaScript(textEditorControl.Text))
            {
                toolStripStatusLabel_Form.Text = $"Error compiling JavaScript";
            }
            Properties.Settings.Default.PAC_JavaScript = textEditorControl.Text;
        }
        private void ToolStripMenuItem_OpenPAC_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "PAC;DAT|*.pac;*.dat|All Files|*.*",
                FileName = "proxy.pac",
                DefaultExt = "pac",
                Title = "Open Proxy Auto-Config File",
            })
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                toolStripTextBox_Search.Clear();
                textEditorControl_Editor.Text = File.ReadAllText(openFileDialog.FileName);
                toolStripStatusLabel_Form.Text = $"PAC File Loaded: {openFileDialog.FileName}";
                Properties.Settings.Default.PAC_FileName = openFileDialog.FileName;
            }
        }
        private void ToolStripMenuItem_SavePAC_Click(object sender, EventArgs e)
        {
            if (!CompileJavaScript(textEditorControl_Editor.Text))
            {
                if (MessageBox.Show(
                    "There are errors in the current PAC file.\nSave anyway?\n",
                    "Errors in PAC File",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                    ) != DialogResult.Yes)
                {
                    return;
                }
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "PAC;DAT|*.pac;*.dat|All Files|*.*",
                FileName = Properties.Settings.Default.PAC_FileName,
                DefaultExt = "pac",
                Title = "Save Proxy Auto-Config File",
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                File.WriteAllText(saveFileDialog.FileName, textEditorControl_Editor.Text);
                toolStripStatusLabel_Form.Text = $"PAC File Saved: {saveFileDialog.FileName}";
                Properties.Settings.Default.PAC_FileName = saveFileDialog.FileName;
            }
        }
        private void ToolStripMenuItem_ToggleColor_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_ToggleColor.BackColor = (toolStripMenuItem_ToggleColor.Checked) ? SystemColors.InactiveCaption : Color.Transparent;
            toolStripMenuItem_ToggleColor.ForeColor = (toolStripMenuItem_ToggleColor.Checked) ? SystemColors.InactiveCaptionText : SystemColors.ControlText;
            textEditorControl_Editor.SetHighlighting(toolStripMenuItem_ToggleColor.Checked ? "ProxyAutoConfig" : "Default");
            Properties.Settings.Default.ToggleColor = toolStripMenuItem_ToggleColor.Checked;
        }
        private void ToolStripMenuItem_ToggleGlyphs_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ToggleGlyphs =
                textEditorControl_Editor.ShowSpaces =
                textEditorControl_Editor.ShowEOLMarkers =
                textEditorControl_Editor.ShowTabs = toolStripMenuItem_ToggleGlyphs.Checked;

            toolStripMenuItem_ToggleGlyphs.BackColor = (toolStripMenuItem_ToggleGlyphs.Checked) ? SystemColors.InactiveCaption : Color.Transparent;
            toolStripMenuItem_ToggleGlyphs.ForeColor = (toolStripMenuItem_ToggleGlyphs.Checked) ? SystemColors.InactiveCaptionText : SystemColors.ControlText;
        }
        private void ToolStripMenuItem_Search_Click(object sender, EventArgs e)
        {
            TextEditorControl editor = textEditorControl_Editor;
            if (editor == null) return;
            _findForm.ShowFor(editor, false);
        }
        private void ToolStripTextBox_Search_TextChanged(object sender, EventArgs e)
        {
            TextEditorControl editor = textEditorControl_Editor;
            if (editor == null) return;
            _findForm.HighlightForText(editor, toolStripTextBox_Search.Text);
            textEditorControl_Editor.Refresh();
        }
        private void ToolStripMenuItem_Settings_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Utils
        private bool CompileJavaScript(string pacJavaScript)
        {
            string jsPAC = $"{pacJavaScript}\r\n" + $"var window=null;\r\n" + $"var document=null;\r\n" + $"{Properties.Resources.PAC_Functions}";
            webBrowser_Results.Document.InvokeScript("__clearMessages");
            try
            {
                object Result = Microsoft.JScript.Eval.JScriptEvaluate(jsPAC, Engine);
            }
            catch (Microsoft.JScript.JScriptException jex)
            {
                string message = $"JavaScript Syntax Error: line:{jex.Line} column:{jex.Column}\r\n{jex.Message}\r\n";
                LogMessageToPac($"{message}");
                return false;
            }
            catch (Exception ex)
            {
                string message = $"JavaScript Exception:\r\n{ExceptionMessageRecurse(ex)}\r\n";
                LogMessageToPac($"{message}");
                return false;
            }
            return true;
        }
        private string DiscoverMyIpAddress(string host)
        {
            if (string.IsNullOrEmpty(host = GetIPAddress(host, SrcDstIP.SrcIP)))
            {
                return host;
            }

            UnicastIPAddressInformation mostSuitableIp = null;
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;
                var properties = network.GetIPProperties();
                if (properties.GatewayAddresses.Count == 0)
                    continue;
                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;
                    if (IPAddress.IsLoopback(address.Address))
                        continue;
                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }
                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }
                    return address.Address.ToString();
                }
            }
            return mostSuitableIp != null ? $"{mostSuitableIp.Address}" : "";

        }
        private static string ExceptionMessageRecurse(Exception ex)
        {
            if (ex == null) { return string.Empty; }
            string innerException = $"{ex.GetType().Name}: {ex.Message}";
            if (ex.InnerException != null)
            {
                innerException += $"{Environment.NewLine}Inner:{ExceptionMessageRecurse(ex.InnerException)}";
            }
            return innerException;
        }
        private string GetIPAddress(string host, SrcDstIP srcDstIP)
        {
            if (IsResolvable(host))
            {
                try
                {
                    // try to create a UDP packet to host, but don't send packet.
                    // routing tables should automatically select the best srcIP.
                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                    {
                        socket.Connect(host, 53);
                        IPAddress srcIp = ((IPEndPoint)socket.LocalEndPoint).Address;
                        IPAddress dstIP = ((IPEndPoint)socket.RemoteEndPoint).Address;
                        return (srcDstIP == SrcDstIP.SrcIP) ? $"{srcIp}" : $"{dstIP}";
                    }
                }
                catch //(Exception ex)
                {
                    //the socket method didn't work. probably host unresolvable.
                }
            }
            return string.Empty;
        }
        private string GetProxyForUrlUsingPacFile(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
            {
                toolStripStatusLabel_Form.Text = ($"Invalid URL Entered");
                return null;
            }
            InitializeWebBrowser_Results();
            //discover myIpAddress
            if (toolStripMenuItem_AutoIP.Checked)
            {
                toolStripTextBox_AutoIP.Text = DiscoverMyIpAddress(uri.Host);
            }
            object result = webBrowser_Results.Document.InvokeScript(
                (toolStripMenuItem_FindProxyForURLEx.Checked)
                ? "__FindProxyForURLEx"
                : "__FindProxyForURL",
                new object[] { uri.ToString(), uri.Host }
                );
            return result == null ? "DIRECT" : $"{result}";
        }
        private void InitializeWebBrowser_Results()
        {
            webBrowser_Results.Document.OpenNew(true);
            webBrowser_Results.Navigate("about:blank");
            webBrowser_Results.ObjectForScripting = this;
            webBrowser_Results.DocumentText = Properties.Resources.PAC_Html.Replace("${PAC_Functions}", Properties.Resources.PAC_Functions)
                .Replace("${PAC_JavaScript}", Properties.Settings.Default.PAC_JavaScript)
                //just in case these get formatted improperly by editor
                .Replace("${ PAC_Functions }", Properties.Resources.PAC_Functions)
                .Replace("${ PAC_JavaScript }", Properties.Settings.Default.PAC_JavaScript);

            if (!CompileJavaScript(Properties.Settings.Default.PAC_JavaScript))
            {
                return;
            }
            while (webBrowser_Results.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

        }
        private static bool IPStringToIPv6NumberAndAddress(string ipString, out IPAddress ipAddress, out BigInteger ipNumber)
        {
            bool status = false;
            ipAddress = null;
            ipNumber = 0;
            if (status = IPAddress.TryParse(ipString.Trim(), out ipAddress))
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork) ipAddress = ipAddress.MapToIPv6();
                byte[] IPv6AddressBytes = ipAddress.GetAddressBytes();
                if (BitConverter.IsLittleEndian) Array.Reverse(IPv6AddressBytes); //little-endian
                ipNumber = BitConverter.ToUInt64(IPv6AddressBytes, 8);
                ipNumber <<= 64;
                ipNumber += BitConverter.ToUInt64(IPv6AddressBytes, 0);
            }
            return status;
        }
        private static bool IsValidIPv4(string addr)
        {
            string hostType;
            bool valid = true;

            if (!(String.IsNullOrEmpty(addr)))
            {
                hostType = Uri.CheckHostName(addr).ToString();
                if (hostType != "IPv4")
                    valid = false;
            }
            //must have 3 dots
            if (addr.Length - addr.Replace(".", "").Length != 3)
            {
                valid = false;
            }
            return valid;
        }
        #endregion

        #region External Calls from JavaScript
        //FindProxyForURL
        public string DnsResolve(string host)
        {
            if (IsValidIPv4(host))
            {
                return host;
            }
            return GetIPAddress(host, SrcDstIP.DstIP);
        }
        public void LogMessageFromPac(string message)
        {
            //Display(DisplayTo.ResultsLog, $"{message}", DisplayLevel.Debug, false);
        }
        public void LogMessageToPac(string message)
        {
            webBrowser_Results.Document.InvokeScript("__logMessage", new object[] { message });
        }
        public string MyIpAddress()
        {
            //actual IP is pulled from the form, which is populated when you hit the Test button.
            return toolStripTextBox_AutoIP.Text;
        }
        public bool IsResolvable(string host)
        {
            if (String.IsNullOrEmpty(host)) return false;
            int millisecond_time_out = 1000;
            ResolveState ioContext = new ResolveState(host);
            var result = Dns.BeginGetHostEntry(ioContext.HostName, null, null);
            var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(millisecond_time_out), true);
            if (!success)
            {
                ioContext.Result = Resolvetype.Timeout;
            }
            else
            {
                try
                {
                    var ipList = Dns.EndGetHostEntry(result);
                    if (ipList == null || ipList.AddressList == null || ipList.AddressList.Length == 0)
                        ioContext.Result = Resolvetype.InvalidHost;
                    else
                        ioContext.Result = Resolvetype.Completed;
                }
                catch
                {
                    ioContext.Result = Resolvetype.InvalidHost;
                }
            }
            return (ioContext.Result == Resolvetype.Completed);
        }

        //FindProxyForURLEx
        public string SortIpAddressList(string ipAddressList)
        {
            // not really based on chrome source, but inspired by it.
            //https://chromium.googlesource.com/chromium/src/+/master/url/url_canon_ip.cc

            try
            {
                string[] IPAddressStrings = ipAddressList.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (IPAddressStrings.Length > 1024)
                {
                    LogMessageToPac($"<b style='color:red'>SortIpAddressList: List too long ({IPAddressStrings.Length} &gt; 1024</b>\r\n");
                    return string.Empty;
                }
                if (IPAddressStrings.Length == 1) return ipAddressList.Trim();

                List<KeyValuePair<BigInteger, IPAddress>> ipv4SortList = new List<KeyValuePair<BigInteger, IPAddress>>();
                List<KeyValuePair<BigInteger, IPAddress>> ipv6SortList = new List<KeyValuePair<BigInteger, IPAddress>>();

                for (int i = 0; i < IPAddressStrings.Length; i++)
                {
                    if (!IPStringToIPv6NumberAndAddress(IPAddressStrings[i], out IPAddress ipAddress, out BigInteger ipNumber))
                    {
                        LogMessageToPac($"<b style='color:red'>SortIpAddressList: Error in IP address: ({IPAddressStrings[i]})</b>\r\n");
                        return string.Empty;
                    }
                    if (ipAddress.IsIPv4MappedToIPv6)
                    {
                        ipv4SortList.Add(new KeyValuePair<BigInteger, IPAddress>(ipNumber, ipAddress));
                    }
                    else
                    {
                        ipv6SortList.Add(new KeyValuePair<BigInteger, IPAddress>(ipNumber, ipAddress));
                    }
                }
                List<string> ipList = new List<string>();
                foreach (KeyValuePair<BigInteger, IPAddress> keyValuePair in ipv6SortList.OrderBy(n => n.Key))
                {
                    ipList.Add(keyValuePair.Value.ToString());
                }
                foreach (KeyValuePair<BigInteger, IPAddress> keyValuePair in ipv4SortList.OrderBy(n => n.Key))
                {
                    ipList.Add(keyValuePair.Value.MapToIPv4().ToString());
                }

                return String.Join(";", ipList.ToArray());
            }
            catch (Exception ex)
            {
                LogMessageToPac($"<b style='color:red'>SortIpAddressList: Exception:\r\n{ExceptionMessageRecurse(ex)}</b>\r\n");
                return string.Empty;
            }
        }
        // adapted from from Microsoft-https://referencesource.microsoft.com/#System/net/System/Net/_AutoWebProxyScriptHelper.cs     
        public string MyIpAddressEx()
        {
            try
            {
                IPAddress[] ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                List<string> addressList = new List<string>();
                for (int i = 0; i < ipAddresses.Length; i++)
                {
                    if (IPAddress.IsLoopback(ipAddresses[i])) continue;
                    addressList.Add(ipAddresses[i].ToString());
                }
                return string.Join(";", addressList);
            }
            catch { return string.Empty; }
        }
        public bool IsInNetEx(string ipAddress, string ipPrefix)
        {
            if (ipAddress == null) { return false; }
            if (ipPrefix == null) { return false; }
            if (!IPAddress.TryParse(ipAddress, out IPAddress address))
            {
                return false;
            }
            int prefixSeparatorIndex = ipPrefix.IndexOf("/");
            if (prefixSeparatorIndex < 0)
            {
                return false;
            }
            string[] parts = ipPrefix.Split(new char[] { '/' });
            if (parts.Length != 2 || parts[0] == null || parts[0].Length == 0 ||
                parts[1] == null || parts[1].Length == 0 || parts[1].Length > 2)
            {
                return false;
            }
            if (!IPAddress.TryParse(parts[0], out IPAddress prefixAddress))
            {
                return false;
            }
            if (!Int32.TryParse(parts[1], out int prefixLength))
            {
                return false;
            }
            if (address.AddressFamily != prefixAddress.AddressFamily)
            {
                return false;
            }
            if (
                ((address.AddressFamily == AddressFamily.InterNetworkV6) && (prefixLength < 1 || prefixLength > 64)) ||
                ((address.AddressFamily == AddressFamily.InterNetwork) && (prefixLength < 1 || prefixLength > 32))
                )
            {
                return false;
            }
            byte[] prefixAddressBytes = prefixAddress.GetAddressBytes();
            byte prefixBytes = (byte)(prefixLength / 8);
            byte prefixExtraBits = (byte)(prefixLength % 8);
            byte i = prefixBytes;
            if (prefixExtraBits != 0)
            {
                if ((0xFF & (prefixAddressBytes[prefixBytes] << prefixExtraBits)) != 0)
                {
                    return false;
                }
                i++;
            }
            int MaxBytes = (prefixAddress.AddressFamily == AddressFamily.InterNetworkV6) ? 16 : 4;
            while (i < MaxBytes)
            {
                if (prefixAddressBytes[i++] != 0)
                {
                    return false;
                }
            }
            byte[] addressBytes = address.GetAddressBytes();
            for (i = 0; i < prefixBytes; i++)
            {
                if (addressBytes[i] != prefixAddressBytes[i])
                {
                    return false;
                }
            }
            if (prefixExtraBits > 0)
            {
                byte addrbyte = addressBytes[prefixBytes];
                byte prefixbyte = prefixAddressBytes[prefixBytes];

                //Clear 8 - Remaining bits from the addr byte
                addrbyte = (byte)(addrbyte >> (8 - prefixExtraBits));
                addrbyte = (byte)(addrbyte << (8 - prefixExtraBits));
                if (addrbyte != prefixbyte)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsResolvableEx(string host)
        {
            if (String.IsNullOrEmpty(host)) return false;
            IPHostEntry ipHostEntry = null;
            try
            {
                ipHostEntry = Dns.GetHostByName(host);
            }
            catch { }
            if (ipHostEntry == null)
            {
                return false;
            }
            IPAddress[] addresses = ipHostEntry.AddressList;
            if (addresses.Length == 0)
            {
                return false;
            }
            return true;
        }
        public string DnsResolveEx(string host)
        {
            if (host == null)
            {
                return string.Empty;
            }
            IPHostEntry ipHostEntry = null;
            try
            {
                ipHostEntry = Dns.GetHostByName(host);
            }
            catch { }
            if (ipHostEntry == null)
            {
                return string.Empty;
            }
            IPAddress[] addresses = ipHostEntry.AddressList;
            if (addresses.Length == 0)
            {
                return string.Empty;
            }

            List<string> addressList = new List<string>();

            for (int i = 0; i < addresses.Length; i++)
            {
                addressList.Add(addresses[i].ToString());
            }
            return string.Join(";", addressList);
        }
        #endregion

    }
}

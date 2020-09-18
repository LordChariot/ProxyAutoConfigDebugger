namespace ProxyAutoConfigDebugger
{
    partial class ProxyAutoConfigDebugger_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProxyAutoConfigDebugger_Form));
            this.menuStrip_Form = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_Uri = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_Uri = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem_Test = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Spacer_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FindProxyForURLEx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_AutoIP = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem_AutoIP = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer_Form = new System.Windows.Forms.SplitContainer();
            this.groupBox_Editor = new System.Windows.Forms.GroupBox();
            this.textEditorControl_Editor = new ICSharpCode.TextEditor.TextEditorControl();
            this.menuStrip_Editor = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_OpenPAC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SavePAC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ToggleGlyphs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ToggleColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Search = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_Search = new System.Windows.Forms.ToolStripTextBox();
            this.groupBox_Results = new System.Windows.Forms.GroupBox();
            this.webBrowser_Results = new System.Windows.Forms.WebBrowser();
            this.statusStrip_Form = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Form = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip_Form.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Form)).BeginInit();
            this.splitContainer_Form.Panel1.SuspendLayout();
            this.splitContainer_Form.Panel2.SuspendLayout();
            this.splitContainer_Form.SuspendLayout();
            this.groupBox_Editor.SuspendLayout();
            this.menuStrip_Editor.SuspendLayout();
            this.groupBox_Results.SuspendLayout();
            this.statusStrip_Form.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_Form
            // 
            this.menuStrip_Form.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Uri,
            this.toolStripComboBox_Uri,
            this.toolStripMenuItem_Test,
            this.toolStripMenuItem_About,
            this.toolStripMenuItem_Settings,
            this.toolStripMenuItem_Spacer_1,
            this.toolStripMenuItem_FindProxyForURLEx,
            this.toolStripTextBox_AutoIP,
            this.toolStripMenuItem_AutoIP});
            this.menuStrip_Form.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Form.Name = "menuStrip_Form";
            this.menuStrip_Form.ShowItemToolTips = true;
            this.menuStrip_Form.Size = new System.Drawing.Size(1008, 27);
            this.menuStrip_Form.TabIndex = 0;
            this.menuStrip_Form.Text = "menuStrip_Form";
            // 
            // toolStripMenuItem_Uri
            // 
            this.toolStripMenuItem_Uri.Name = "toolStripMenuItem_Uri";
            this.toolStripMenuItem_Uri.Size = new System.Drawing.Size(40, 23);
            this.toolStripMenuItem_Uri.Text = "URI:";
            // 
            // toolStripComboBox_Uri
            // 
            this.toolStripComboBox_Uri.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.toolStripComboBox_Uri.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolStripComboBox_Uri.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBox_Uri.Name = "toolStripComboBox_Uri";
            this.toolStripComboBox_Uri.Size = new System.Drawing.Size(300, 23);
            this.toolStripComboBox_Uri.ToolTipText = "Enter URI";
            this.toolStripComboBox_Uri.TextChanged += new System.EventHandler(this.ToolStripComboBox_Uri_TextChanged);
            // 
            // toolStripMenuItem_Test
            // 
            this.toolStripMenuItem_Test.AutoToolTip = true;
            this.toolStripMenuItem_Test.CheckOnClick = true;
            this.toolStripMenuItem_Test.Enabled = false;
            this.toolStripMenuItem_Test.Image = global::ProxyAutoConfigDebugger.Properties.Resources.CSTest_16x;
            this.toolStripMenuItem_Test.Name = "toolStripMenuItem_Test";
            this.toolStripMenuItem_Test.Size = new System.Drawing.Size(55, 23);
            this.toolStripMenuItem_Test.Text = "Test";
            this.toolStripMenuItem_Test.ToolTipText = "Test URI";
            this.toolStripMenuItem_Test.Click += new System.EventHandler(this.ToolStripMenuItem_Test_Click);
            this.toolStripMenuItem_Test.MouseEnter += new System.EventHandler(this.ToolStripMenuItem_MouseEnter);
            this.toolStripMenuItem_Test.MouseLeave += new System.EventHandler(this.ToolStripMenuItem_MouseLeave);
            // 
            // toolStripMenuItem_About
            // 
            this.toolStripMenuItem_About.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_About.AutoToolTip = true;
            this.toolStripMenuItem_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem_About.Image = global::ProxyAutoConfigDebugger.Properties.Resources.UIAboutBox_16x;
            this.toolStripMenuItem_About.Name = "toolStripMenuItem_About";
            this.toolStripMenuItem_About.Size = new System.Drawing.Size(28, 23);
            this.toolStripMenuItem_About.Text = "About";
            this.toolStripMenuItem_About.Click += new System.EventHandler(this.ToolStripMenuItem_About_Click);
            this.toolStripMenuItem_About.MouseEnter += new System.EventHandler(this.ToolStripMenuItem_MouseEnter);
            this.toolStripMenuItem_About.MouseLeave += new System.EventHandler(this.ToolStripMenuItem_MouseLeave);
            // 
            // toolStripMenuItem_Settings
            // 
            this.toolStripMenuItem_Settings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_Settings.AutoToolTip = true;
            this.toolStripMenuItem_Settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem_Settings.Image = global::ProxyAutoConfigDebugger.Properties.Resources.Settings_16x;
            this.toolStripMenuItem_Settings.Name = "toolStripMenuItem_Settings";
            this.toolStripMenuItem_Settings.Size = new System.Drawing.Size(28, 23);
            this.toolStripMenuItem_Settings.Text = "Settings";
            this.toolStripMenuItem_Settings.Visible = false;
            this.toolStripMenuItem_Settings.Click += new System.EventHandler(this.ToolStripMenuItem_Settings_Click);
            this.toolStripMenuItem_Settings.MouseEnter += new System.EventHandler(this.ToolStripMenuItem_MouseEnter);
            this.toolStripMenuItem_Settings.MouseLeave += new System.EventHandler(this.ToolStripMenuItem_MouseLeave);
            // 
            // toolStripMenuItem_Spacer_1
            // 
            this.toolStripMenuItem_Spacer_1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_Spacer_1.Name = "toolStripMenuItem_Spacer_1";
            this.toolStripMenuItem_Spacer_1.Size = new System.Drawing.Size(22, 23);
            this.toolStripMenuItem_Spacer_1.Text = "|";
            // 
            // toolStripMenuItem_FindProxyForURLEx
            // 
            this.toolStripMenuItem_FindProxyForURLEx.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_FindProxyForURLEx.CheckOnClick = true;
            this.toolStripMenuItem_FindProxyForURLEx.Image = global::ProxyAutoConfigDebugger.Properties.Resources.CheckBoxUnchecked_16x;
            this.toolStripMenuItem_FindProxyForURLEx.Name = "toolStripMenuItem_FindProxyForURLEx";
            this.toolStripMenuItem_FindProxyForURLEx.Size = new System.Drawing.Size(132, 23);
            this.toolStripMenuItem_FindProxyForURLEx.Text = "FindProxyForUrlEx";
            this.toolStripMenuItem_FindProxyForURLEx.ToolTipText = "Check to support FindProxyForURLEx()";
            this.toolStripMenuItem_FindProxyForURLEx.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_FindProxyForURLEx_CheckedChanged);
            this.toolStripMenuItem_FindProxyForURLEx.MouseEnter += new System.EventHandler(this.ToolStripMenuItem_MouseEnter);
            this.toolStripMenuItem_FindProxyForURLEx.MouseLeave += new System.EventHandler(this.ToolStripMenuItem_MouseLeave);
            // 
            // toolStripTextBox_AutoIP
            // 
            this.toolStripTextBox_AutoIP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox_AutoIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_AutoIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox_AutoIP.Name = "toolStripTextBox_AutoIP";
            this.toolStripTextBox_AutoIP.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_AutoIP.Text = "127.0.0.1";
            this.toolStripTextBox_AutoIP.ToolTipText = "Enter the source IP Address to emulate.";
            // 
            // toolStripMenuItem_AutoIP
            // 
            this.toolStripMenuItem_AutoIP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem_AutoIP.Checked = true;
            this.toolStripMenuItem_AutoIP.CheckOnClick = true;
            this.toolStripMenuItem_AutoIP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem_AutoIP.Image = global::ProxyAutoConfigDebugger.Properties.Resources.CheckBoxChecked_16x;
            this.toolStripMenuItem_AutoIP.Name = "toolStripMenuItem_AutoIP";
            this.toolStripMenuItem_AutoIP.Size = new System.Drawing.Size(77, 23);
            this.toolStripMenuItem_AutoIP.Text = "Auto IP:";
            this.toolStripMenuItem_AutoIP.ToolTipText = "Check to use detected IP. Un-check to enter manual IP.\r\n";
            this.toolStripMenuItem_AutoIP.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_AutoIP_CheckedChanged);
            this.toolStripMenuItem_AutoIP.MouseEnter += new System.EventHandler(this.ToolStripMenuItem_MouseEnter);
            this.toolStripMenuItem_AutoIP.MouseLeave += new System.EventHandler(this.ToolStripMenuItem_MouseLeave);
            // 
            // splitContainer_Form
            // 
            this.splitContainer_Form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Form.Location = new System.Drawing.Point(0, 27);
            this.splitContainer_Form.Name = "splitContainer_Form";
            // 
            // splitContainer_Form.Panel1
            // 
            this.splitContainer_Form.Panel1.Controls.Add(this.groupBox_Editor);
            this.splitContainer_Form.Panel1MinSize = 512;
            // 
            // splitContainer_Form.Panel2
            // 
            this.splitContainer_Form.Panel2.Controls.Add(this.groupBox_Results);
            this.splitContainer_Form.Panel2MinSize = 250;
            this.splitContainer_Form.Size = new System.Drawing.Size(1008, 552);
            this.splitContainer_Form.SplitterDistance = 512;
            this.splitContainer_Form.TabIndex = 1;
            // 
            // groupBox_Editor
            // 
            this.groupBox_Editor.Controls.Add(this.textEditorControl_Editor);
            this.groupBox_Editor.Controls.Add(this.menuStrip_Editor);
            this.groupBox_Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Editor.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Editor.Name = "groupBox_Editor";
            this.groupBox_Editor.Size = new System.Drawing.Size(512, 552);
            this.groupBox_Editor.TabIndex = 0;
            this.groupBox_Editor.TabStop = false;
            this.groupBox_Editor.Text = "Proxy Auto-Configuration Editor";
            // 
            // textEditorControl_Editor
            // 
            this.textEditorControl_Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl_Editor.IsReadOnly = false;
            this.textEditorControl_Editor.Location = new System.Drawing.Point(3, 48);
            this.textEditorControl_Editor.Name = "textEditorControl_Editor";
            this.textEditorControl_Editor.ShowInvalidLines = true;
            this.textEditorControl_Editor.ShowVRuler = false;
            this.textEditorControl_Editor.Size = new System.Drawing.Size(506, 501);
            this.textEditorControl_Editor.TabIndex = 0;
            this.textEditorControl_Editor.TextChanged += new System.EventHandler(this.TextEditorControl_Editor_TextChanged);
            // 
            // menuStrip_Editor
            // 
            this.menuStrip_Editor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_OpenPAC,
            this.toolStripMenuItem_SavePAC,
            this.toolStripMenuItem_ToggleGlyphs,
            this.toolStripMenuItem_ToggleColor,
            this.toolStripMenuItem_Search,
            this.toolStripTextBox_Search});
            this.menuStrip_Editor.Location = new System.Drawing.Point(3, 21);
            this.menuStrip_Editor.Name = "menuStrip_Editor";
            this.menuStrip_Editor.ShowItemToolTips = true;
            this.menuStrip_Editor.Size = new System.Drawing.Size(506, 27);
            this.menuStrip_Editor.TabIndex = 1;
            this.menuStrip_Editor.Text = "menuStrip_Editor";
            // 
            // toolStripMenuItem_OpenPAC
            // 
            this.toolStripMenuItem_OpenPAC.AutoToolTip = true;
            this.toolStripMenuItem_OpenPAC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem_OpenPAC.Image = global::ProxyAutoConfigDebugger.Properties.Resources.OpenFile_16x;
            this.toolStripMenuItem_OpenPAC.Name = "toolStripMenuItem_OpenPAC";
            this.toolStripMenuItem_OpenPAC.Size = new System.Drawing.Size(28, 23);
            this.toolStripMenuItem_OpenPAC.Text = "Open PAC";
            this.toolStripMenuItem_OpenPAC.Click += new System.EventHandler(this.ToolStripMenuItem_OpenPAC_Click);
            // 
            // toolStripMenuItem_SavePAC
            // 
            this.toolStripMenuItem_SavePAC.AutoToolTip = true;
            this.toolStripMenuItem_SavePAC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem_SavePAC.Image = global::ProxyAutoConfigDebugger.Properties.Resources.Save_16x;
            this.toolStripMenuItem_SavePAC.Name = "toolStripMenuItem_SavePAC";
            this.toolStripMenuItem_SavePAC.Size = new System.Drawing.Size(28, 23);
            this.toolStripMenuItem_SavePAC.Text = "Save PAC";
            this.toolStripMenuItem_SavePAC.Click += new System.EventHandler(this.ToolStripMenuItem_SavePAC_Click);
            // 
            // toolStripMenuItem_ToggleGlyphs
            // 
            this.toolStripMenuItem_ToggleGlyphs.AutoToolTip = true;
            this.toolStripMenuItem_ToggleGlyphs.Checked = true;
            this.toolStripMenuItem_ToggleGlyphs.CheckOnClick = true;
            this.toolStripMenuItem_ToggleGlyphs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem_ToggleGlyphs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem_ToggleGlyphs.Image = global::ProxyAutoConfigDebugger.Properties.Resources.Paragraph_16x;
            this.toolStripMenuItem_ToggleGlyphs.Name = "toolStripMenuItem_ToggleGlyphs";
            this.toolStripMenuItem_ToggleGlyphs.Size = new System.Drawing.Size(28, 23);
            this.toolStripMenuItem_ToggleGlyphs.Text = "Toggle Glyphs";
            this.toolStripMenuItem_ToggleGlyphs.Click += new System.EventHandler(this.ToolStripMenuItem_ToggleGlyphs_Click);
            // 
            // toolStripMenuItem_ToggleColor
            // 
            this.toolStripMenuItem_ToggleColor.AutoToolTip = true;
            this.toolStripMenuItem_ToggleColor.Checked = true;
            this.toolStripMenuItem_ToggleColor.CheckOnClick = true;
            this.toolStripMenuItem_ToggleColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem_ToggleColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem_ToggleColor.Image = global::ProxyAutoConfigDebugger.Properties.Resources.StyleSheet_16x;
            this.toolStripMenuItem_ToggleColor.Name = "toolStripMenuItem_ToggleColor";
            this.toolStripMenuItem_ToggleColor.Size = new System.Drawing.Size(28, 23);
            this.toolStripMenuItem_ToggleColor.Text = "Toggle Color";
            this.toolStripMenuItem_ToggleColor.Click += new System.EventHandler(this.ToolStripMenuItem_ToggleColor_Click);
            // 
            // toolStripMenuItem_Search
            // 
            this.toolStripMenuItem_Search.AutoToolTip = true;
            this.toolStripMenuItem_Search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem_Search.Image = global::ProxyAutoConfigDebugger.Properties.Resources.Search_16x;
            this.toolStripMenuItem_Search.Name = "toolStripMenuItem_Search";
            this.toolStripMenuItem_Search.Size = new System.Drawing.Size(28, 23);
            this.toolStripMenuItem_Search.Text = "Search";
            this.toolStripMenuItem_Search.Click += new System.EventHandler(this.ToolStripMenuItem_Search_Click);
            // 
            // toolStripTextBox_Search
            // 
            this.toolStripTextBox_Search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_Search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox_Search.Name = "toolStripTextBox_Search";
            this.toolStripTextBox_Search.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_Search.ToolTipText = "Search Text";
            this.toolStripTextBox_Search.TextChanged += new System.EventHandler(this.ToolStripTextBox_Search_TextChanged);
            // 
            // groupBox_Results
            // 
            this.groupBox_Results.Controls.Add(this.webBrowser_Results);
            this.groupBox_Results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Results.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Results.Name = "groupBox_Results";
            this.groupBox_Results.Size = new System.Drawing.Size(492, 552);
            this.groupBox_Results.TabIndex = 0;
            this.groupBox_Results.TabStop = false;
            this.groupBox_Results.Text = "Results";
            // 
            // webBrowser_Results
            // 
            this.webBrowser_Results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_Results.Location = new System.Drawing.Point(3, 21);
            this.webBrowser_Results.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_Results.Name = "webBrowser_Results";
            this.webBrowser_Results.Size = new System.Drawing.Size(486, 528);
            this.webBrowser_Results.TabIndex = 0;
            this.webBrowser_Results.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            // 
            // statusStrip_Form
            // 
            this.statusStrip_Form.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Form});
            this.statusStrip_Form.Location = new System.Drawing.Point(0, 579);
            this.statusStrip_Form.Name = "statusStrip_Form";
            this.statusStrip_Form.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip_Form.TabIndex = 0;
            this.statusStrip_Form.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Form
            // 
            this.toolStripStatusLabel_Form.Name = "toolStripStatusLabel_Form";
            this.toolStripStatusLabel_Form.Size = new System.Drawing.Size(128, 17);
            this.toolStripStatusLabel_Form.Text = "Enter URI and click Test";
            // 
            // ProxyAutoConfigDebugger_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.splitContainer_Form);
            this.Controls.Add(this.statusStrip_Form);
            this.Controls.Add(this.menuStrip_Form);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_Form;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "ProxyAutoConfigDebugger_Form";
            this.Text = "Proxy Auto-Config Debugger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProxyAutoConfigDebugger_Form_FormClosing);
            this.Load += new System.EventHandler(this.ProxyAutoConfigDebugger_Form_Load);
            this.menuStrip_Form.ResumeLayout(false);
            this.menuStrip_Form.PerformLayout();
            this.splitContainer_Form.Panel1.ResumeLayout(false);
            this.splitContainer_Form.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Form)).EndInit();
            this.splitContainer_Form.ResumeLayout(false);
            this.groupBox_Editor.ResumeLayout(false);
            this.groupBox_Editor.PerformLayout();
            this.menuStrip_Editor.ResumeLayout(false);
            this.menuStrip_Editor.PerformLayout();
            this.groupBox_Results.ResumeLayout(false);
            this.statusStrip_Form.ResumeLayout(false);
            this.statusStrip_Form.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_Form;
        private System.Windows.Forms.SplitContainer splitContainer_Form;
        private System.Windows.Forms.GroupBox groupBox_Editor;
        private System.Windows.Forms.GroupBox groupBox_Results;
        private System.Windows.Forms.StatusStrip statusStrip_Form;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Uri;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Uri;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Test;
        private System.Windows.Forms.WebBrowser webBrowser_Results;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AutoIP;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_AutoIP;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_FindProxyForURLEx;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Spacer_1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_About;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Settings;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Form;
        private System.Windows.Forms.MenuStrip menuStrip_Editor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_OpenPAC;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SavePAC;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ToggleGlyphs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ToggleColor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Search;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Search;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl_Editor;
    }
}


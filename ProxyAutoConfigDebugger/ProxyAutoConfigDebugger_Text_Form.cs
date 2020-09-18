using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyAutoConfigDebugger
{
    public partial class ProxyAutoConfigDebugger_Text_Form : Form
    {
        public string TextFile { get; set; } = string.Empty;
        public ProxyAutoConfigDebugger_Text_Form()
        {
            InitializeComponent();
        }

        private void ProxyAutoDebugger_Text_Form_Load(object sender, EventArgs e)
        {
            textBox1.Text = TextFile;
            textBox1.Select(0, 0);
        }
    }
}

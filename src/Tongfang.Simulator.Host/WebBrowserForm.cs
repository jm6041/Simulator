using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tongfang.Simulator.Host
{
    public partial class WebBrowserForm : Form
    {
        private string _content;

        public WebBrowserForm(string content)
        {
            _content = content;
            InitializeComponent();
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            webBrowserContent.DocumentText = "";
        }

        private void WebBrowserForm_Load(object sender, EventArgs e)
        {
            this.webBrowserContent.DocumentText = "<div>" + _content + "</div>";
        }
    }
}

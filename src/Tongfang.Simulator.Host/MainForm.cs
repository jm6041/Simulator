using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tongfang.AuthMessage.Service;
using Tongfang.Simulator.Host.Properties;
using Tongfang.Winform.Helpers;

namespace Tongfang.Simulator.Host
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenServiceHost();
        }

        private void OpenServiceHost()
        {
            ServiceHostHelper.Instance.OpenServerHost();
            AppendState(Resources.MqStart);
            btnStart.Enabled = false;
            btnClose.Enabled = true;
        }

        private void CloseServiceHost()
        {
            ServiceHostHelper.Instance.CloseServerHost();
            AppendState(Resources.MqEnd);
            btnStart.Enabled = true;
            btnClose.Enabled = false;
        }

        private void ServiceHostMessage_Opened(object sender, EventArgs e)
        {
            AppendState(Resources.MqStart);
            btnStart.Enabled = false;
            btnClose.Enabled = true;
        }

        private void ServiceHostMessage_Closed(object sender, EventArgs e)
        {
            AppendState(Resources.MqEnd);
            btnStart.Enabled = true;
            btnClose.Enabled = false;
        }

        private delegate void DelegateUpdateUIPro(string content);

        private void AppendState(string input)
        {
            string text = string.Format("{0:yyyy-MM-dd HH:mm:ss:ffff}: {1}{2}", DateTime.Now, input, Environment.NewLine);
            if (textState.InvokeRequired)
            {
                this.BeginInvoke(new DelegateUpdateUIPro((x) =>
                {
                    textState.AppendText(x);
                }));
            }
            else
            {
                textState.AppendText(text);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            OpenServiceHost();
        }

        private void ExceptionHandler(Exception ex)
        {
            string error = ErrorWrapper.GetExceptionDesc(ex);
            ErrorWrapper errorWrapper = ErrorWrapper.Instance;
            errorWrapper.AppendError(error);
            errorWrapper.Show();
        }

        private void btnShowError_Click(object sender, EventArgs e)
        {
            ErrorWrapper.Instance.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseServiceHost();
        }

        private void AppendMessage(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("--------------------{0:yyyy-MM-dd HH:mm:ss:ffff} 收到消息--------------------", DateTime.Now);
            sb.AppendLine();
            sb.Append(msg);
            sb.Append("----------------------------------------------------");
            string text = sb.ToString();
            if (textState.InvokeRequired)
            {
                this.BeginInvoke(new DelegateUpdateUIPro((x) =>
                {
                    textContent.AppendText(x);
                }));
            }
            else
            {
                textContent.AppendText(text);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseServiceHost();
        }
    }
}

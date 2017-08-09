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
        private ServiceHost _serviceHostMessage;

        public MainForm()
        {
            InitializeComponent();
            InitServiceHost();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenServiceHost();
        }

        private void InitServiceHost()
        {
            MsMqHelper.CreateMsMq();
            _serviceHostMessage = new ServiceHost(typeof(MessageService));
            _serviceHostMessage.Opened += ServiceHostMessage_Opened;
            _serviceHostMessage.Closed += ServiceHostMessage_Closed;
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

        private void OpenServiceHost()
        {
            _serviceHostMessage?.Open();
        }

        private void CloseServiceHost()
        {
            _serviceHostMessage?.Close();
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
            throw new ArgumentException("模拟异常", new ArgumentNullException("模拟内部异常"));
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
            throw new ArgumentException("模拟异常", new ArgumentNullException("模拟内部异常"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private ServiceHostRunner _runner;
        private PublishClientWrapper _client;
        private Guid _clientId;

        /// <summary>
        /// Excel模板文件
        /// </summary>
        private static readonly string AppType = ConfigurationManager.AppSettings["AppType"] ?? "Server";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitRunner();
            OpenServiceHost();
            InitPublishClient();
        }

        private void InitRunner()
        {
            if (AppType.ToUpper().Contains("Server".ToUpper()))
            {
                _runner = ServiceHostRunner.Instance;
                _runner.PublishServiceHostOpening += Runner_PublishServiceHostOpening;
                _runner.PublishServiceHostOpened += Runner_PublishServiceHostOpened;
                _runner.PublishServiceHostClosing += Runner_PublishServiceHostClosing;
                _runner.PublishServiceHostClosed += Runner_PublishServiceHostClosed;

                _runner.MessageServiceHostOpening += Runner_MessageServiceHostOpening;
                _runner.MessageServiceHostOpened += Runner_MessageServiceHostOpened;
                _runner.MessageServiceHostClosing += Runner_MessageServiceHostClosing;
                _runner.MessageServiceHostClosed += Runner_MessageServiceHostClosed;
            }
        }

        private void Runner_MessageServiceHostClosed(object sender, EventArgs e)
        {
            AppendState("消息服务已经关闭。");
        }

        private void Runner_MessageServiceHostClosing(object sender, EventArgs e)
        {
            AppendState("消息服务开始关闭。");
        }

        private void Runner_MessageServiceHostOpened(object sender, EventArgs e)
        {
            AppendState("消息服务已经打开。");
        }

        private void Runner_MessageServiceHostOpening(object sender, EventArgs e)
        {
            AppendState("消息服务开始打开。");
        }

        private void Runner_PublishServiceHostClosed(object sender, EventArgs e)
        {
            AppendState("发布服务已经关闭。");
        }

        private void Runner_PublishServiceHostClosing(object sender, EventArgs e)
        {
            AppendState("发布服务开始关闭。");
        }

        private void Runner_PublishServiceHostOpening(object sender, EventArgs e)
        {
            AppendState("发布服务开始打开。");
        }

        private void Runner_PublishServiceHostOpened(object sender, EventArgs e)
        {
            AppendState("发布服务已经打开");
        }

        private void OpenServiceHost()
        {
            _runner?.Open();
            btnStart.Enabled = false;
            btnClose.Enabled = true;
        }

        private void CloseServiceHost()
        {
            _runner?.Close();
            btnStart.Enabled = true;
            btnClose.Enabled = false;
        }

        private void InitPublishClient()
        {
            PublishCallback clientCallback = new PublishCallback();
            clientCallback.ClientReceived += ClientCallback_ClientReceived;
            _client = new PublishClientWrapper(clientCallback, "PublishServiceInnerClient");
            _clientId = _client.Subscribe();
            ShowConnectCount(_client.GetConnectCount());
            AppendState(string.Format("连接发布服务器成功，客户端ID:{0}", _clientId));
        }

        private void ClientCallback_ClientReceived(object sender, ClientReceivedEventArgs e)
        {
            AppendMessage(e.Message);
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
            sb.AppendFormat("---------------{0:yyyy-MM-dd HH:mm:ss:ffff} 收到消息---------------", DateTime.Now);
            sb.AppendLine();
            sb.Append(msg);
            sb.AppendLine();
            sb.AppendLine("---------------------------------------------------------------");
            string text = sb.ToString();
            if (textState.InvokeRequired)
            {
                this.BeginInvoke(new DelegateUpdateUIPro((x) =>
                {
                    textContent.AppendText(x);
                    labelContent.Text = string.Format("内容({0})", textContent.Text.Length);
                }));
            }
            else
            {
                textContent.AppendText(text);
                labelContent.Text = string.Format("内容({0})", textContent.Text.Length);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseServiceHost();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string msg = textSend.Text;
            await _client.PublishMessageAsync(msg);
            textSend.Clear();
        }

        private void linkLabelCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int count = _client.GetConnectCount();
            ShowConnectCount(count);
        }

        /// <summary>
        /// 显示连接数据
        /// </summary>
        /// <param name="count">连接数</param>
        private void ShowConnectCount(int count)
        {
            if (labelLinkCount.InvokeRequired)
            {
                this.BeginInvoke(new DelegateUpdateUIPro((x) =>
                {
                    labelLinkCount.Text = count.ToString();
                }));
            }
            else
            {
                labelLinkCount.Text = count.ToString();
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            textContent.Clear();
            labelContent.Text = "内容({0})";
        }

        private void btnCleanState_Click(object sender, EventArgs e)
        {
            textState.Clear();
        }
    }
}

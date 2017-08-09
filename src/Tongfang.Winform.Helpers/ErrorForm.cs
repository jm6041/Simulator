using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tongfang.Winform.Helpers
{
    internal partial class ErrorForm : Form
    {
        /// <summary>
        /// 是否释放对象，默认不释放
        /// </summary>
        private bool _disposableValue;
        /// <summary>
        /// 指定释放释放对象
        /// </summary>
        public bool DisposableValue { get => _disposableValue; set => _disposableValue = value; }

        public ErrorForm()
        {
            _disposableValue = false;
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearError();
        }

        public void ClearError()
        {
            richTextBoxError.Clear();
        }

        private delegate void DelegateUpdateUIPro(string content);

        public void AppendError(string input)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new DelegateUpdateUIPro((x) =>
                {
                    UpdateError(x);
                }));
            }
            else
            {
                UpdateError(input);
            }
        }

        private void UpdateError(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }
            int length = labelLength.Text.Length;
            int inputLength = input.Length;
            int max = richTextBoxError.MaxLength;
            // 合计
            long total = length + inputLength;
            if (total > max)
            {
                richTextBoxError.Clear();
                total = inputLength;
            }
            richTextBoxError.AppendText(input);
            labelLength.Text = total.ToString();
        }

        /// <summary>
        /// 显示指定释放对象
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (_disposableValue)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            else
            {
                Visible = false;
            }
        }

        /// <summary>
        /// 关闭用隐藏代替
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visible = false;
            base.OnClosing(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

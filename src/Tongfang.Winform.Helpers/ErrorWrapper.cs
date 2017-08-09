using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tongfang.Winform.Helpers
{
    /// <summary>
    /// 包装异常处理
    /// </summary>
    public sealed class ErrorWrapper: IDisposable
    {
        private static readonly Lazy<ErrorWrapper> lazy = new Lazy<ErrorWrapper>(() => new ErrorWrapper());
        public static ErrorWrapper Instance { get { return lazy.Value; } }
        private ErrorWrapper()
        {
            _errorForm = new ErrorForm();
        }

        private ErrorForm _errorForm;

        public void Show()
        {
            _errorForm.Visible = true;
        }

        public void Show(IWin32Window owner)
        {
            _errorForm.Show(owner);
        }

        public DialogResult ShowDialog()
        {
            return _errorForm.ShowDialog();
        }

        public DialogResult ShowDialog(IWin32Window owner)
        {
            return _errorForm.ShowDialog(owner);
        }

        public void Hide()
        {
            _errorForm.Hide();
        }

        public void AppendError(string input)
        {
            _errorForm.AppendError(input);
        }

        public void ClearError()
        {
            _errorForm.ClearError();
        }

        /// <summary>
        /// 是否创建了实例
        /// </summary>
        public static bool IsValueCreated
        {
            get
            {
                return lazy.IsValueCreated;
            }
        }

        public void Dispose()
        {
            if (lazy.IsValueCreated)
            {
                _errorForm.DisposableValue = true;
                _errorForm.Dispose();
            }
        }

        public bool Visible
        {
            get { return _errorForm.Visible; }
            set { _errorForm.Visible = value; }
        }

        /// <summary>
        /// 获得异常描述
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns>异常描述信息</returns>
        public static string GetExceptionDesc(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------------------------------------------------");
            GetExceptionDesc(ex, sb);
            sb.AppendLine("--------------------------------------------------------");
            return sb.ToString();
        }

        private static void GetExceptionDesc(Exception ex, StringBuilder sb)
        {
            sb.AppendLine(GetExceptionContent(ex));
            if (ex.InnerException != null)
            {
                GetExceptionDesc(ex.InnerException, sb);
            }
        }

        private static string GetExceptionContent(Exception ex)
        {
            string text = string.Format("时间:{0:yyyy-MM-dd HH:mm:ss ffff} - Exception:{1} - {2}{3}",
                DateTime.Now, ex.GetType().Name, ex.Message, Environment.NewLine);
#if DEBUG
            text += string.Format("StackTrace:{0}{1}", ex.StackTrace, Environment.NewLine);
#endif
            return text;
        }        
    }
}

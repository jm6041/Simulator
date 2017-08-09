using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Tongfang.AuthMessage.Service
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    [ServiceContract(Namespace = "http://www.tongfangcloud.com/")]
    public interface IEmailService
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="email">邮件地址</param>
        /// <param name="subject">主题</param>
        /// <param name="message">内容</param>
        /// <returns></returns>
        [OperationContract(IsOneWay = true)]
        Task SendEmailAsync(string email, string subject, string message);
    }
}

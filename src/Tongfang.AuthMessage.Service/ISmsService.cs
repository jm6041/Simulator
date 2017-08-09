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
    /// 发送短信
    /// </summary>
    [ServiceContract(Namespace = "http://www.tongfangcloud.com/")]
    public interface ISmsService
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="number">电话号码</param>
        /// <param name="message">内容</param>
        /// <returns></returns>
        [OperationContract(IsOneWay = true)]
        Task SendSmsAsync(string number, string message);
    }
}

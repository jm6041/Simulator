using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Tongfang.AuthMessage.Service
{
    /// <summary>
    /// 消息发布服务
    /// </summary>
    [ServiceContract(Namespace = "http://www.tongfangcloud.com/", CallbackContract = typeof(IPublishCallback))]
    public interface IPublishService
    {
        /// <summary>
        /// 客户端注册时的Id
        /// </summary>
        /// <returns>唯一标示客户端</returns>
        [OperationContract]
        Guid Subscribe();

        /// <summary>
        /// 取消客户端
        /// </summary>
        /// <param name="clientId">客服端标示</param>
        [OperationContract(IsOneWay = true)]
        void Unsubscribe(Guid clientId);

        /// <summary>
        /// 广播一个消息到其它客服端
        /// </summary>
        /// <param name="message"></param>
        [OperationContract]
        Task PublishMessageAsync(string message);

        /// <summary>
        /// 获得连接数
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int GetConnectCount();
    }

    /// <summary>
    /// 回调函数
    /// </summary>
    public interface IPublishCallback
    {
        /// <summary>
        /// 消息处理函数
        /// </summary>
        /// <param name="message"></param>
        [OperationContract(IsOneWay = true)]
        void MessageHandler(string message);
    }
}

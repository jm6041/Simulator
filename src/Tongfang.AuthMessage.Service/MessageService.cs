using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Tongfang.AuthMessage.Service
{
    /// <summary>
    /// Email，Sms模拟服务实现
    /// </summary>
    public class MessageService : IEmailService, ISmsService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine("SessionId:{0}   email:{1}   subject:{2}   message:{3}",
                OperationContext.Current.SessionId, email, subject, message);

            System.Diagnostics.Debug.WriteLine(AppDomain.CurrentDomain.FriendlyName);
#endif
            await PublishClientWrapper.Instance.PublishMessageAsync(
                   string.Format("email:{0}   subject:{1}{2}message:{3}",
                   email, subject, Environment.NewLine, message));
        }

        public async Task SendSmsAsync(string number, string message)
        {
            try
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("SessionId:{0}   number:{1}   message:{2}",
                    OperationContext.Current.SessionId, number, message);

                System.Diagnostics.Debug.WriteLine(AppDomain.CurrentDomain.FriendlyName);
#endif
                await PublishClientWrapper.Instance.PublishMessageAsync(
                    string.Format("number:{0}{1}message:{2}",
                    number, Environment.NewLine, message));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }

    /// <summary>
    /// 消息发布服务实现
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PublishService : IPublishService
    {
        /// <summary>
        /// 记录客户端信息
        /// </summary>
        private readonly ConcurrentDictionary<Guid, IPublishCallback> clients = new ConcurrentDictionary<Guid, IPublishCallback>();

        /// <summary>
        /// 订阅
        /// </summary>
        /// <returns></returns>
        public Guid Subscribe()
        {
            IPublishCallback callback = OperationContext.Current.GetCallbackChannel<IPublishCallback>();
            if (callback != null)
            {
                Guid clientId = Guid.NewGuid();
                bool isSuccess = clients.TryAdd(clientId, callback);
                if (isSuccess)
                {
                    return clientId;
                }
            }
            return Guid.Empty;
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="clientId"></param>
        public void Unsubscribe(Guid clientId)
        {
            IPublishCallback callback;
            clients.TryRemove(clientId, out callback);
        }

        /// <summary>
        /// 获得连接数量
        /// </summary>
        /// <returns></returns>
        public int GetConnectCount()
        {
            return clients.Count;
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public async Task PublishMessageAsync(string message)
        {
            System.Diagnostics.Debug.WriteLine(AppDomain.CurrentDomain.FriendlyName);

            List<Guid> disconnectedClientGuids = new List<Guid>();
            foreach (KeyValuePair<Guid, IPublishCallback> client in clients)
            {
                try
                {
                    await Task.Factory.StartNew(() => client.Value.MessageHandler(message));
                }
                catch (Exception)
                {
                    disconnectedClientGuids.Add(client.Key);
                }

            }
            foreach (Guid clientGuid in disconnectedClientGuids)
            {
                IPublishCallback callback;
                clients.TryRemove(clientGuid, out callback);
            }
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Tongfang.AuthMessage.Service
{
    /// <summary>
    /// 发布服务客户端
    /// </summary>
    public class PublishServiceClient : DuplexClientBase<IPublishService>, IPublishService
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="callbackInstance"><see cref="InstanceContext"/></param>
        /// <param name="endpointConfigurationName">终结点配置名</param>
        public PublishServiceClient(InstanceContext callbackInstance, string endpointConfigurationName) 
            :                base(callbackInstance, endpointConfigurationName)
        {
        }

        public PublishServiceClient(object callbackInstance, ServiceEndpoint endpoint)
            : base(callbackInstance, endpoint)
        {
        }

        public Guid Subscribe()
        {
            return base.Channel.Subscribe();
        }

        public void Unsubscribe(Guid clientId)
        {
            base.Channel.Unsubscribe(clientId);
        }

        public async Task PublishMessageAsync(string message)
        {
            await base.Channel.PublishMessageAsync(message);
        }

        public int GetConnectCount()
        {
            return base.Channel.GetConnectCount();
        }
    }
}

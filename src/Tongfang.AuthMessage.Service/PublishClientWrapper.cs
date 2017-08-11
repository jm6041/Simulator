using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Tongfang.AuthMessage.Service
{
    /// <summary>
    /// 回调函数
    /// </summary>
    internal class PublishClientCallback : IPublishCallback
    {
        public void MessageHandler(string message)
        {
        }
    }

    /// <summary>
    /// 包装发布客户端，仅用于内部服务直接发送消息
    /// </summary>
    internal class PublishClientWrapper
    {
        private static readonly string PublishServiceInnerClientName = "PublishServiceInnerClient";
        /// <summary>
        /// 使用延迟加载，实现单例模式
        /// </summary>
        private static readonly Lazy<PublishClientWrapper> lazy = new Lazy<PublishClientWrapper>(() => new PublishClientWrapper());
        public static PublishClientWrapper Instance { get { return lazy.Value; } }
        private PublishClientWrapper()
        {
            this._publishClientCallback = new PublishClientCallback();
            this._instanceContext = new InstanceContext(this._publishClientCallback);
            this._publishServiceClient = new PublishServiceClient(_instanceContext, PublishServiceInnerClientName);
            clientId = _publishServiceClient.Subscribe();
        }

        private Guid clientId;
        private PublishClientCallback _publishClientCallback;
        private InstanceContext _instanceContext;
        private PublishServiceClient _publishServiceClient;

        private void CreateMsgServiceClient()
        {
            if (_publishServiceClient == null)
            {
                _publishServiceClient = new PublishServiceClient(_instanceContext, PublishServiceInnerClientName);
            }
            else if (_publishServiceClient.State == CommunicationState.Closed)
            {
                _publishServiceClient = new PublishServiceClient(_instanceContext, PublishServiceInnerClientName);
            }
            else if (_publishServiceClient.State == CommunicationState.Faulted)
            {
                _publishServiceClient.Abort();
                _publishServiceClient = new PublishServiceClient(_instanceContext, PublishServiceInnerClientName);
            }
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public async Task PublishMessageAsync(string msg)
        {
            CreateMsgServiceClient();
            await _publishServiceClient.PublishMessageAsync(msg);
        }
    }
}

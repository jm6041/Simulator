using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Tongfang.AuthMessage.Service;

namespace Tongfang.Simulator.Host
{
    /// <summary>
    /// 回调函数实现
    /// </summary>
    public class PublishCallback : IPublishCallback
    {
        /// <summary>
        /// 客户端接收到消息的事件
        /// </summary>
        public event ClientReceivedEventHandler ClientReceived;
        /// <summary>
        /// 实现接口
        /// </summary>
        /// <param name="message">接收到的消息</param>
        public void MessageHandler(string message)
        {
            ClientReceived?.Invoke(this, new ClientReceivedEventArgs(message));
        }
    }
    /// <summary>
    /// 客户端接收到消息的事件处理委托
    /// </summary>
    /// <param name="sender">事件触发对象</param>
    /// <param name="e">事件参数</param>
    public delegate void ClientReceivedEventHandler(object sender, ClientReceivedEventArgs e);
    /// <summary>
    /// 客户端接收到消息事件的传递参数
    /// </summary>
    public class ClientReceivedEventArgs : EventArgs
    {
        private readonly string message;

        public ClientReceivedEventArgs(string message)
        {
            this.message = message;
        }
        public string Message { get { return message; } }
    }

    /// <summary>
    /// 包装发布客户端，确保客户端正确
    /// </summary>
    public class PublishClientWrapper : IPublishService
    {
        public PublishClientWrapper(IPublishCallback callbackInstance, string endpointConfigurationName)
        {
            this._publishCallback = callbackInstance;
            this._callbackInstance = new InstanceContext(_publishCallback);
            this._client = CreateClient(_callbackInstance, endpointConfigurationName);
            this._serviceEndpoint = _client.Endpoint;
        }

        private IPublishCallback _publishCallback;
        private InstanceContext _callbackInstance;
        private PublishServiceClient _client;
        private ServiceEndpoint _serviceEndpoint;

        private bool _clientIsRight = true;

        private static PublishServiceClient CreateClient(InstanceContext callbackInstance, string endpointConfigurationName)
        {
            return new PublishServiceClient(callbackInstance, endpointConfigurationName);
        }

        private static PublishServiceClient CreateClient(InstanceContext callbackInstance, ServiceEndpoint serviceEndpoint)
        {
            return new PublishServiceClient(callbackInstance, serviceEndpoint);
        }

        /// <summary>
        /// Client是否一致保持正确
        /// </summary>
        public bool ClientIsRight { get => _clientIsRight; set => _clientIsRight = value; }

        /// <summary>
        /// 保证Client是正确可用的
        /// </summary>
        /// <param name="callbackInstance"></param>
        /// <param name="endpointConfigurationName"></param>
        private void InsureClient()
        {
            if (_clientIsRight)
            {
                if (_client.State == CommunicationState.Closed)
                {
                    _client = CreateClient(_callbackInstance, _serviceEndpoint);
                }
                else if (_client.State == CommunicationState.Faulted)
                {
                    _client.Abort();
                    _client = new PublishServiceClient(_callbackInstance, _serviceEndpoint);
                }
            }
        }

        #region IPublishService
        public Guid Subscribe()
        {
            InsureClient();
            return _client.Subscribe();
        }

        public void Unsubscribe(Guid clientId)
        {
            InsureClient();
            _client.Unsubscribe(clientId);
        }

        public async Task PublishMessageAsync(string message)
        {
            InsureClient();
            await _client.PublishMessageAsync(message);
        }

        public int GetConnectCount()
        {
            InsureClient();
            return _client.GetConnectCount();
        }
        #endregion
    }
}

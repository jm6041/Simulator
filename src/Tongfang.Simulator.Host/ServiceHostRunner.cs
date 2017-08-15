using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tongfang.AuthMessage.Service;

namespace Tongfang.Simulator.Host
{
    public sealed class ServiceHostRunner : MarshalByRefObject
    {
        private static readonly Lazy<ServiceHostRunner> lazy = new Lazy<ServiceHostRunner>(() => new ServiceHostRunner());
        public static ServiceHostRunner Instance { get { return lazy.Value; } }
        private AppDomain _serviceHostDomain;
        private bool isOpen = false;
        private ServiceHost _publishServiceHost;
        private ServiceHost _messageServiceHost;

        /// <summary>
        /// <see cref="PublishService"/>通信对象转换到正在打开状态时发生
        /// </summary>
        public event EventHandler PublishServiceHostOpening;
        /// <summary>
        /// <see cref="PublishService"/>通信对象转换到已打开状态时发生。
        /// </summary>
        public event EventHandler PublishServiceHostOpened;
        /// <summary>
        /// <see cref="PublishService"/>通信对象转换到正在关闭状态时发生。
        /// </summary>
        public event EventHandler PublishServiceHostClosing;
        /// <summary>
        /// <see cref="PublishService"/>通信对象转换到已关闭状态时发生。
        /// </summary>
        public event EventHandler PublishServiceHostClosed;

        /// <summary>
        /// <see cref="MessageService"/>通信对象转换到正在打开状态时发生
        /// </summary>
        public event EventHandler MessageServiceHostOpening;
        /// <summary>
        /// <see cref="MessageService"/>通信对象转换到已打开状态时发生。
        /// </summary>
        public event EventHandler MessageServiceHostOpened;
        /// <summary>
        /// <see cref="MessageService"/>通信对象转换到正在关闭状态时发生。
        /// </summary>
        public event EventHandler MessageServiceHostClosing;
        /// <summary>
        /// <see cref="MessageService"/>通信对象转换到已关闭状态时发生。
        /// </summary>
        public event EventHandler MessageServiceHostClosed;


        public void Open()
        {
            if (_serviceHostDomain == null)
            {
                _serviceHostDomain = AppDomain.CreateDomain("ServiceHostDomain");
            }
            if (!isOpen)
            {
                _serviceHostDomain.DoCallBack(() =>
                {
                    _publishServiceHost = new ServiceHost(typeof(PublishService));
                    _publishServiceHost.Opening += PublishServiceHost_Opening;
                    _publishServiceHost.Opened += PublishServiceHost_Opened;
                    _publishServiceHost.Closing += PublishServiceHost_Closing;
                    _publishServiceHost.Closed += PublishServiceHost_Closed;

                    _messageServiceHost = new ServiceHost(typeof(MessageService));
                    _messageServiceHost.Opening += MessageServiceHost_Opening;
                    _messageServiceHost.Opened += MessageServiceHost_Opened;
                    _messageServiceHost.Closing += MessageServiceHost_Closing;
                    _messageServiceHost.Closed += MessageServiceHost_Closed;

                    _publishServiceHost.Open();
                    _messageServiceHost.Open();
                });
                isOpen = true;
            }
        }

        private void PublishServiceHost_Closed(object sender, EventArgs e)
        {
            PublishServiceHostClosed?.Invoke(sender, e);
        }

        private void PublishServiceHost_Closing(object sender, EventArgs e)
        {
            PublishServiceHostClosing?.Invoke(sender, e);
        }

        private void PublishServiceHost_Opening(object sender, EventArgs e)
        {
            PublishServiceHostOpening?.Invoke(sender, e);
        }

        private void PublishServiceHost_Opened(object sender, EventArgs e)
        {
            PublishServiceHostOpened?.Invoke(sender, e);
        }

        private void MessageServiceHost_Closed(object sender, EventArgs e)
        {
            MessageServiceHostClosed?.Invoke(sender, e);
        }

        private void MessageServiceHost_Closing(object sender, EventArgs e)
        {
            MessageServiceHostClosing?.Invoke(sender, e);
        }

        private void MessageServiceHost_Opening(object sender, EventArgs e)
        {
            MessageServiceHostOpening?.Invoke(sender, e);
        }

        private void MessageServiceHost_Opened(object sender, EventArgs e)
        {
            MessageServiceHostOpened?.Invoke(sender, e);
        }

        public void Close()
        {
            if (isOpen)
            {
                _messageServiceHost.Close();
                _publishServiceHost.Close();
                AppDomain.Unload(_serviceHostDomain);
                _serviceHostDomain = null;
                isOpen = false;
            }
        }
    }
}

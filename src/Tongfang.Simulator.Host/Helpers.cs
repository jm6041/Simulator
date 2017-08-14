using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tongfang.AuthMessage.Service;

namespace Tongfang.Simulator.Host
{
    public sealed class ServiceHostHelper
    {
        private static readonly Lazy<ServiceHostHelper> lazy = new Lazy<ServiceHostHelper>(() => new ServiceHostHelper());
        public static ServiceHostHelper Instance { get { return lazy.Value; } }
        private AppDomain _serviceHostDomain;

        private bool isOpen = false;

        public void OpenServerHost()
        {
            if (!isOpen)
            {
                _serviceHostDomain = AppDomain.CreateDomain("ServiceHostDomain");
                _serviceHostDomain.DoCallBack(() =>
                {
                    PublishServiceHost publishServiceHost = new PublishServiceHost();
                    publishServiceHost.Open();

                    MessageServiceHost messageServiceHost = new MessageServiceHost();
                    messageServiceHost.Open();
                });
                isOpen = true;
            }
        }

        public void CloseServerHost()
        {
            if (isOpen)
            {
                AppDomain.Unload(_serviceHostDomain);
                isOpen = false;
            }
        }
    }
}

using System;
using System.ServiceModel;

namespace Tongfang.AuthMessage.Service
{
    /// <summary>
    /// Message服务主机
    /// </summary>
    [Serializable]
    public class MessageServiceHost : ServiceHost
    {
        /// <summary>
        /// AssemblyName
        /// </summary>
        public static readonly string AssemblyName;
        /// <summary>
        /// TypeName
        /// </summary>
        public static readonly string TypeName;

        static MessageServiceHost()
        {
            Type t = typeof(MessageServiceHost);
            AssemblyName = t.Assembly.FullName;
            TypeName = t.FullName;
        }

        public MessageServiceHost() : base(typeof(MessageService))
        {
        }

    }

    /// <summary>
    /// Publish服务主机
    /// </summary>
    [Serializable]
    public class PublishServiceHost : ServiceHost
    {
        /// <summary>
        /// AssemblyName
        /// </summary>
        public static readonly string AssemblyName;
        /// <summary>
        /// TypeName
        /// </summary>
        public static readonly string TypeName;

        static PublishServiceHost()
        {
            Type t = typeof(PublishServiceHost);
            AssemblyName = t.Assembly.FullName;
            TypeName = t.FullName;
        }

        public PublishServiceHost() : base(typeof(PublishService))
        {
        }
    }
}

using System.Configuration;
using System.Messaging;
using Tongfang.Simulator.Host.Properties;

namespace Tongfang.Simulator.Host
{
    /// <summary>
    /// MsMq帮助类
    /// </summary>
    public static class MsMqHelper
    {
        /// <summary>
        /// Sms服务的消息队列完整路径名
        /// </summary>
        public static readonly string QueueNameSmsService = ConfigurationManager.AppSettings["QueueNameSmsService"] ?? @".\private$\Simulator_MSMQ_Sms";

        /// <summary>
        /// Email服务的消息队列完整路径名
        /// </summary>
        public static readonly string QueueNameEmailService = ConfigurationManager.AppSettings["QueueNameEmailService"] ?? @".\private$\Simulator_MSMQ_Email";

        /// <summary>
        /// 创建消息队列
        /// </summary>
        public static void CreateMsMq()
        {
            CreateSmsMq();
            CreateEmailMq();
        }

        /// <summary>
        /// 创建Sms消息队列
        /// </summary>
        /// <remarks>创建系统需要的消息队列</remarks>
        public static void CreateSmsMq()
        {
            string queueName = QueueNameSmsService;
            if (!MessageQueue.Exists(queueName))
            {
                MessageQueue mq = MessageQueue.Create(queueName, true);
                mq.Label = Resources.MsMqLabelSms;
                // 给管理员组赋完全控制权限
                mq.SetPermissions("Administrators", MessageQueueAccessRights.FullControl);
                // Windows Service 以SYSTEM组权限运行，因此在Windows Service中启动MSMQ，必须给SYSTEM组赋MSMQ完全控制权限
                mq.SetPermissions("SYSTEM", MessageQueueAccessRights.FullControl);
            }
        }

        /// <summary>
        /// 创建Email消息队列
        /// </summary>
        /// <remarks>创建系统需要的消息队列</remarks>
        public static void CreateEmailMq()
        {
            string queueName = QueueNameEmailService;
            if (!MessageQueue.Exists(queueName))
            {
                MessageQueue mq = MessageQueue.Create(queueName, true);
                mq.Label = Resources.MsMqLabelEmail;
                // 给管理员组赋完全控制权限
                mq.SetPermissions("Administrators", MessageQueueAccessRights.FullControl);
                // Windows Service 以SYSTEM组权限运行，因此在Windows Service中启动MSMQ，必须给SYSTEM组赋MSMQ完全控制权限
                mq.SetPermissions("SYSTEM", MessageQueueAccessRights.FullControl);
            }
        }
    }
}

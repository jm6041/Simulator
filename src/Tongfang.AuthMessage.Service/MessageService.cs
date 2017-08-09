using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Tongfang.AuthMessage.Service
{
    [ServiceBehavior(ReleaseServiceInstanceOnTransactionComplete = true, TransactionIsolationLevel = IsolationLevel.RepeatableRead, ConcurrencyMode = ConcurrencyMode.Single)]
    public class MessageService : IEmailService, ISmsService
    {
        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        public Task SendEmailAsync(string email, string subject, string message)
        {
#if DEBUG
            var context = OperationContext.Current;
            string action = context.RequestContext.RequestMessage.Headers.Action;
            System.Diagnostics.Debug.WriteLine("SessionId:{0}   Action:{1}   email:{2}   subject:{3}   message:{4}",
                context.SessionId, action, email, subject, message);
#endif
            throw new NotImplementedException();
        }

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        public Task SendSmsAsync(string number, string message)
        {
#if DEBUG
            var context = OperationContext.Current;
            string action = context.RequestContext.RequestMessage.Headers.Action;
            System.Diagnostics.Debug.WriteLine("SessionId:{0}   Action:{1}   number:{2}   message:{3}",
                context.SessionId, action, number, message);
#endif
            throw new NotImplementedException();
        }
    }
}

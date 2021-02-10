using Coravel.Invocable;
using Masny.DotNet.TransactionSystem.WebApi.Interfaces;
using System;
using System.Threading.Tasks;

namespace Masny.DotNet.TransactionSystem.WebApi.Jobs
{
    public class ProcessTransactionJob : IInvocable, IInvocableWithPayload<Guid>
    {
        private readonly ITransactionManager _transactionManager;

        public ProcessTransactionJob(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager ?? throw new ArgumentNullException(nameof(transactionManager));
        }

        public Guid Payload { get; set; }

        public async Task Invoke()
        {
            await _transactionManager.RunAsync(Payload);
        }
    }
}
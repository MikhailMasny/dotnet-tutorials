using System;
using System.Threading.Tasks;

namespace Masny.DotNet.TransactionSystem.WebApi.Interfaces
{
    public interface ITransactionManager
    {
        Task RunAsync(Guid payload);
    }
}
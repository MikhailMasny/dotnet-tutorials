using Masny.DotNet.DataTransfer.ClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.DotNet.DataTransfer.ClientService.Interfaces
{
    public interface IFakeBankService
    {
        IEnumerable<Account> Get();

        (bool operationResult, Account account) Transfer(Guid id);

        void Save(Account account);
    }
}

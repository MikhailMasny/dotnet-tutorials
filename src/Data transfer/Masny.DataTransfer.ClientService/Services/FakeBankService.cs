using Bogus;
using Masny.DataTransfer.ClientService.Enums;
using Masny.DataTransfer.ClientService.Helpers;
using Masny.DataTransfer.ClientService.Interfaces;
using Masny.DataTransfer.ClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Masny.DataTransfer.ClientService.Services
{
    public class FakeBankService : IFakeBankService
    {
        private readonly IList<Account> _accounts = new List<Account>();

        public FakeBankService(IRequestService requestService)
        {
            if (ApplicationConfig.GenerateDate)
            {
                Randomizer.Seed = new Random(8675309);

                for (int i = 0; i < 10; i++)
                {
                    var user = requestService.GetUserFromApiAsync().GetAwaiter().GetResult();

                    var account = (Account)AccountGenerator();
                    account.UserId = user.User.Id;

                    var rnd = new Random();
                    for (int j = 0; j < rnd.Next(1, 3); j++)
                    {
                        var card = (Card)CardGenerator();
                        card.OwnerName = $"{user.User.FirstName.ToUpper()} {user.User.LastName.ToUpper()}";
                        account.Cards.Add(card);
                    }

                    _accounts.Add(account);
                }
            }
        }

        public IEnumerable<Account> Get()
        {
            return _accounts;
        }

        public (bool operationResult, Account account) Transfer(Guid id)
        {
            var temp = _accounts.FirstOrDefault(a => a.Number == id);
            if (temp is null)
            {
                return (false, new Account());
            }

            _accounts.Remove(temp);
            return (true, temp);
        }

        public void Save(Account account)
        {
            _accounts.Add(account);
        }

        private Faker<Card> CardGenerator()
        {
            return new Faker<Card>()
                .RuleFor(u => u.Number, f => Guid.NewGuid())
                .RuleFor(u => u.DateExpired, f => f.Date.Future())
                .RuleFor(u => u.Currency, f => f.PickRandomWithout<CurrencyType>(CurrencyType.Unknown))
                .RuleFor(u => u.Amount, f => f.Random.Decimal(0, 100));
        }

        private Faker<Account> AccountGenerator()
        {
            return new Faker<Account>()
                .RuleFor(u => u.Number, f => Guid.NewGuid())
                .RuleFor(u => u.DateExpired, f => f.Date.Future());
        }
    }
}

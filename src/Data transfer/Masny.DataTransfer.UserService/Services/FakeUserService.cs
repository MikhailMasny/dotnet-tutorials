using Bogus;
using Masny.DataTransfer.UserService.Interfaces;
using Masny.DataTransfer.UserService.Models;
using System;
using System.Collections.Generic;
using static Bogus.DataSets.Name;

namespace Masny.DataTransfer.UserService.Services
{
    public class FakeUserService : IFakeUserService
    {
        private readonly List<User> _users = new List<User>();

        public FakeUserService()
        {
            Randomizer.Seed = new Random(8675309);

            for (int i = 0; i < 100; i++)
            {
                _users.Add(Generate());
            }
        }

        public IEnumerable<User> Get()
        {
            return _users;
        }

        private Faker<User> Generate()
        {
            return new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.GenderType, f => f.PickRandom<Gender>())
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(u.GenderType))
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(u.GenderType))
                .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName));
        }
    }
}
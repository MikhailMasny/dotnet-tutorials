using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;

namespace Masny.DotNet.DataTransfer.ClientService.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Gender GenderType { get; set; }
    }
}

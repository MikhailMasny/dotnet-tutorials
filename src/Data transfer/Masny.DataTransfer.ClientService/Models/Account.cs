using System;
using System.Collections.Generic;

namespace Masny.DataTransfer.ClientService.Models
{
    public class Account
    {
        public Guid Number { get; set; }

        public Guid UserId { get; set; }

        public DateTime DateExpired { get; set; }

        public IList<Card> Cards { get; set; } = new List<Card>();
    }
}

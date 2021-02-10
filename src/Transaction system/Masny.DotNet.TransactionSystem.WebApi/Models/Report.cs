using Masny.DotNet.TransactionSystem.WebApi.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Masny.DotNet.TransactionSystem.WebApi.Models
{
    public class Report
    {
        [Key]
        public Guid Guid { get; set; }

        public string Token { get; set; }

        public decimal Value { get; set; }

        public ReportStatusType Status { get; set; }

        public string Description { get; set; }

        public string TransactionIdentifier { get; set; }
    }
}
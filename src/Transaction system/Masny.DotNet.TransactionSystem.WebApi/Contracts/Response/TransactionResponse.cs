﻿namespace Masny.DotNet.TransactionSystem.WebApi.Contracts.Response
{
    public class TransactionResponse
    {
        public string Guid { get; set; }

        public bool IsSuccess { get; set; }

        public string Description { get; set; }
    }
}
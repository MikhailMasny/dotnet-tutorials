namespace Masny.DotNet.TransactionSystem.WebApi.Contracts.Request
{
    public class TransactionRequest
    {
        public string Token { get; set; }

        public decimal Value { get; set; }
    }
}
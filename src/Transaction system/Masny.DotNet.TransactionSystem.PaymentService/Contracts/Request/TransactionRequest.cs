namespace Masny.DotNet.TransactionSystem.PaymentService.Contracts.Request
{
    public class TransactionRequest
    {
        public string Token { get; set; }

        public decimal Value { get; set; }
    }
}
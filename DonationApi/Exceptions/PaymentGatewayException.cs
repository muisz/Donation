namespace DonationApi.Exceptions
{
    public class PaymentGatewayException : Exception
    {

        public PaymentGatewayException() : base() { }
        public PaymentGatewayException(string message) : base(message) { }
        public PaymentGatewayException(string message, Exception inner) : base(message, inner) { }
    }
}
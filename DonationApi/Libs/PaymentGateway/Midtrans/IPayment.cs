using DonationApi.Data;

namespace DonationApi.Libs.PaymentGateway.Midtrans
{
    public interface IPayment
    {
        public string GetCode();
        public PaymentMethod GetPaymentMethod();
        public Task<PaymentResponse> CreatePayment(CreatePayment payment);
    }
}
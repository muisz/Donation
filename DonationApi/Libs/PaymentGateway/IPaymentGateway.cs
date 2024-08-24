using DonationApi.Data;

namespace DonationApi.Libs.PaymentGateway
{
    public interface IPaymentGateway
    {
        public Task<List<PaymentMethod>> GetAvailablePayments();
        public Task<PaymentResponse> CreatePayment(CreatePayment payment);
    }
}
using DonationApi.Data;
using DonationApi.Exceptions;

namespace DonationApi.Libs.PaymentGateway.Midtrans
{
    public class MidtransPaymentGateway : IPaymentGateway
    {
        private readonly IPayment BCABankTransfer;

        public MidtransPaymentGateway(IConfiguration configuration)
        {
            BCABankTransfer = new BCABankTransfer(configuration);
        }

        public Task<List<PaymentMethod>> GetAvailablePayments()
        {
            List<PaymentMethod> paymentMethods = [BCABankTransfer.GetPaymentMethod()];
            return Task.FromResult(paymentMethods);
        }

        public Task<PaymentResponse> CreatePayment(CreatePayment payment)
        {
            if (payment.PaymentMethod == BCABankTransfer.GetCode())
                return BCABankTransfer.CreatePayment(payment);
            
            throw new PaymentGatewayException("Payment method not found");
        }
    }
}
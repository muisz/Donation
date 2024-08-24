using System.Text;
using System.Text.Json;
using DonationApi.Data;
using DonationApi.Exceptions;

namespace DonationApi.Libs.PaymentGateway.Midtrans
{
    public class BCABankTransfer : IPayment
    {
        private readonly PaymentMethod paymentMethod;
        private readonly MidtransClient midtransClient;

        public BCABankTransfer(IConfiguration configuration)
        {
            paymentMethod = new PaymentMethod
            {
                Code = "BCA-TF",
                Name = "BCA Virtual Account",
                Category = "Bank Transfer"
            };
            midtransClient = new MidtransClient(configuration);
        }

        public string GetCode()
        {
            return paymentMethod.Code;
        }

        public PaymentMethod GetPaymentMethod()
        {
            return paymentMethod;
        }

        public async Task<PaymentResponse> CreatePayment(CreatePayment payment)
        {
            string orderId = $"{payment.OrderId}#{paymentMethod.Code}";
            StringContent jsonPayload = new(
                JsonSerializer.Serialize(new
                {
                    payment_type = "bank_transfer",
                    transaction_details = new
                    {
                        order_id = orderId,
                        gross_amount = payment.Amount,
                    },
                    bank_transfer = new
                    {
                        bank = "bca"
                    }
                }),
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await midtransClient.httpClient.PostAsync(
                "/v2/charge",
                jsonPayload
            );

            if (!response.IsSuccessStatusCode)
                throw new PaymentGatewayException(await response.Content.ReadAsStringAsync());
            
            BCABankTransferResponse? BCAResponse = await response.Content.ReadFromJsonAsync<BCABankTransferResponse>();
            if (BCAResponse is null)
                throw new PaymentGatewayException("No response");
            
            string VaNumber = "";
            foreach (BankTransferVANumber Va in BCAResponse.VaNumbers)
            {
                VaNumber = Va.VANumber;
            }
            PaymentResponse paymentResponse = new PaymentResponse
            {
                OrderId = BCAResponse.OrderId,
                PaymentCode = VaNumber,
            };
            return paymentResponse;
        }

    }
}
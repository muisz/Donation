using System.Text.Json.Serialization;

namespace DonationApi.Libs.PaymentGateway.Midtrans
{
    public class BankTransferVANumber
    {
        [JsonPropertyName("bank")]
        public string Bank { get; set; } = null!;

        [JsonPropertyName("va_number")]
        public string VANumber { get; set; } = null!;
    }
}
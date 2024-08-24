using System.Text.Json.Serialization;

namespace DonationApi.Libs.PaymentGateway.Midtrans
{
    public class BCABankTransferResponse
    {
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; } = null!;

        [JsonPropertyName("order_id")]
        public string OrderId { get; set; } = null!;

        [JsonPropertyName("transaction_time")]
        public DateTime TransactionTime { get; set; }
        
        [JsonPropertyName("transaction_status")]
        public string TransactionStatus { get; set; } = null!;

        [JsonPropertyName("va_numbers")]
        public List<BankTransferVANumber> VaNumbers { get; set; } = new List<BankTransferVANumber>();

        [JsonPropertyName("fraud_status")]
        public string FraudStatus { get; set; } = null!;
    }
}
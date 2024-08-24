namespace DonationApi.Data
{
    public class PaymentResponse
    {
        public string OrderId { get; set; } = null!;
        public string PaymentCode { get; set; } = null!;
    }
}
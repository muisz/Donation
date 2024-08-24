namespace DonationApi.Data
{
    public class CreatePayment
    {
        public string OrderId { get; set; } = null!;
        public string OrderName { get; set; } = null!;
        public double Amount { get; set; }
        public string PaymentMethod { get; set; } = null!;
    }
}
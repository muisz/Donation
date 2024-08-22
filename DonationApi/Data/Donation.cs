namespace DonationApi.Data
{
    public class Donation
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double FundingAmount { get; set; }
        public double FundedAmount { get; set; }
        public int DonationTotal { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace DonationApi.Data
{
    public class CreateDonation
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public double FundingAmount { get; set; }
    }
}
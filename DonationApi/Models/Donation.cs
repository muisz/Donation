using System.ComponentModel.DataAnnotations;

namespace DonationApi.Models
{
    public class Donation : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double FundingAmount { get; set; }
        public double FundedAmount { get; set; }
        public int DonationTotal { get; set; }

        public ICollection<Volunteer> Volunteers { get; } = new List<Volunteer>();
    }
}
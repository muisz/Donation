using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DonationApi.Enums;

namespace DonationApi.Models
{
    public class Volunteer : BaseModel
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [ForeignKey(nameof(Donation))]
        public int DonationId { get; set; }
        public Donation Donation { get; set; } = null!;
        public double DonationAmount { get; set; }
        public VoluenteerDonationStatus DonationStatus { get; set; }

        public ICollection<Payment> Payments { get; } = new List<Payment>();
    }
}
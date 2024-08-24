using System.ComponentModel.DataAnnotations;
using DonationApi.Enums;

namespace DonationApi.Models
{
    public class Payment : BaseModel
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string PaymentMethod { get; set; } = null!;
        
        [MaxLength(100)]
        public string OrderName { get; set; } = null!;
        public double Amount { get; set; }

        [MaxLength(100)]
        public string? OrderId { get; set; }
        
        [MaxLength(100)]
        public string? PaymentCode { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
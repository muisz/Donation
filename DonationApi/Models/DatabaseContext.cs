using Microsoft.EntityFrameworkCore;

namespace DonationApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
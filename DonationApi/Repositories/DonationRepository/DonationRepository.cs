using DonationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DonationApi.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly DatabaseContext context;

        public DonationRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<Donation> Create(Donation donation)
        {
            await context.Donations.AddAsync(donation);
            await context.SaveChangesAsync();
            return donation;
        }

        public async Task<ICollection<Donation>> GetAll()
        {
            return await context.Donations
                .AsNoTracking()
                .OrderByDescending(donation => donation.Id)
                .ToListAsync();
        }

        public async Task<Donation?> GetById(int value)
        {
            return await context.Donations.FindAsync(value);
        }
    }
}
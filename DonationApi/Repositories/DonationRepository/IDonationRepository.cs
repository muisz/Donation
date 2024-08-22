using DonationApi.Models;

namespace DonationApi.Repositories
{
    public interface IDonationRepository
    {
        public Task<Donation> Create(Donation donation);
        public Task<ICollection<Donation>> GetAll();
        public Task<Donation?> GetById(int value);
    }
}
using DonationApi.Data;

namespace DonationApi.Services
{
    public interface IDonationService
    {
        public Task<Models.Donation> CreateDonation(CreateDonation donation);
        public Task<List<Models.Donation>> GetDonations();
        public Task<Models.Donation> GetDonation(int id);
    }
}
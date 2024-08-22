using DonationApi.Data;
using DonationApi.Exceptions;
using DonationApi.Repositories;

namespace DonationApi.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository donationRepository;
        public const double MINIMUM_FUNDING = 500000;

        public DonationService(IDonationRepository donationRepository)
        {
            this.donationRepository = donationRepository;
        }

        public async Task<Models.Donation> CreateDonation(CreateDonation donation)
        {
            if (donation.FundingAmount < MINIMUM_FUNDING)
                throw new ClientErrorException("Funding amount below the minimum amount");
            
            Models.Donation newDonation = new Models.Donation
            {
                Name = donation.Name,
                Description = donation.Description,
                FundingAmount = donation.FundingAmount,
                FundedAmount = 0,
                DonationTotal = 0,
                CreatedAt = DateTime.Now.ToUniversalTime(),
            };
            return await donationRepository.Create(newDonation);
        }

        public async Task<List<Models.Donation>> GetDonations()
        {
            ICollection<Models.Donation> donations = await donationRepository.GetAll();
            return donations.ToList();
        }

        public async Task<Models.Donation> GetDonation(int id)
        {
            Models.Donation? donation = await donationRepository.GetById(id);
            return donation != null ? 
                donation : 
                throw new ClientErrorException("Donation not found", StatusCodes.Status404NotFound);
        }
    }
}
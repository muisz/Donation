using DonationApi.Data;
using DonationApi.Exceptions;
using DonationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DonationApi.Controllers
{
    [ApiController()]
    [Route("/api/v1/donations")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService donationService;

        public DonationController(IDonationService donationService)
        {
            this.donationService = donationService;
        }

        [HttpPost]
        public async Task<ActionResult> PostCreateDonation(CreateDonation payload)
        {
            try
            {
                await donationService.CreateDonation(payload);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (ClientErrorException error)
            {
                return Problem(error.Message, statusCode: error.StatusCode);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Donation>>> GetDonations()
        {
            try
            {
                List<Donation> result = new List<Donation>();
                List<Models.Donation> donations = await donationService.GetDonations();
                foreach (Models.Donation donation in donations)
                {
                    result.Add(MapDonation(donation));
                }
                return Ok(result);
            }
            catch (ClientErrorException error)
            {
                return Problem(error.Message, statusCode: error.StatusCode);
            }
        }

        [HttpGet(":id")]
        public async Task<ActionResult<Donation>> GetDonation(int id)
        {
            try
            {
                Models.Donation donation = await donationService.GetDonation(id);
                return Ok(MapDonation(donation));
            }
            catch (ClientErrorException error)
            {
                return Problem(error.Message, statusCode: error.StatusCode);
            }
        }

        private Donation MapDonation(Models.Donation donation)
        {
            return new Donation
            {
                Id = donation.Id,
                Name = donation.Name,
                Description = donation.Description,
                FundingAmount = donation.FundingAmount,
                FundedAmount = donation.FundedAmount,
                DonationTotal = donation.DonationTotal,
                CreatedAt = donation.CreatedAt,
            };
        }
    }
}
using DonationApi.Data;
using DonationApi.Exceptions;
using DonationApi.Libs.PaymentGateway;
using Microsoft.AspNetCore.Mvc;

namespace DonationApi.Controllers
{
    [ApiController]
    [Route("/api/v1/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentGateway paymentGateway;

        public PaymentController(IPaymentGateway paymentGateway)
        {
            this.paymentGateway = paymentGateway;
        }

        [HttpGet("available-methods")]
        public async Task<ActionResult<List<PaymentMethod>>> GetAvailableMethods()
        {
            List<PaymentMethod> paymentMethods = await paymentGateway.GetAvailablePayments();
            return Ok(paymentMethods);
        }

        [HttpPost("test-payment")]
        public async Task<ActionResult<PaymentResponse>> PostTestPayment(CreatePayment payment)
        {
            try
            {
                PaymentResponse response = await paymentGateway.CreatePayment(payment);
                return Ok(response);
            }
            catch (PaymentGatewayException error)
            {
                return Problem(error.Message);
            }
        }
    }
}
using System.Text;

namespace DonationApi.Libs.PaymentGateway.Midtrans
{
    public class MidtransClient
    {
        public HttpClient httpClient;
        private readonly IConfiguration configuration;

        public MidtransClient(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
            SetupHost();
            SetupAuthentication();
        }

        private void SetupHost()
        {
            string host = configuration["Midtrans:Host"] ?? "";
            httpClient.BaseAddress = new Uri(host);
        }

        private void SetupAuthentication()
        {
            string serverKey = configuration["Midtrans:ServerKey"] ?? "";
            byte[] authKey = Encoding.UTF8.GetBytes($"{serverKey}:");
            string authToken = Convert.ToBase64String(authKey);
            
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
                authToken);
        }
    }
}
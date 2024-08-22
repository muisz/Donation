namespace DonationApi.Exceptions
{
    public class ClientErrorException : Exception
    {
        public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;

        public ClientErrorException() : base() { }
        public ClientErrorException(string message) : base(message) { }
        public ClientErrorException(string message, int statusCode) : base(message) { StatusCode = statusCode; }
    }
}
namespace Udemy.Skinet.Api.Errors {
    public class ApiException : ApiResponse {
        public ApiException(int statusCode, string message = null, string details = null) : base(statusCode, message) {
            Details = details;
        }

        public ApiException(System.Net.HttpStatusCode statusCode, string message = null, string details = null) :
            this((int)statusCode, message, details) { }

        public string Details { get; }
    }
}

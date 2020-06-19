using System.Net;

namespace Udemy.Skinet.Api.Errors {
    public class ApiResponse {
        public ApiResponse(int statusCode, string message = null) {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public ApiResponse(HttpStatusCode statusCode, string message = null) : this((int)statusCode, message) { }

        private string GetDefaultMessageForStatusCode(int statusCode) {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors the path to the dark side are. Errors lead to anger." +
                "Anger leads to hate. Hate leads to career change.",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}

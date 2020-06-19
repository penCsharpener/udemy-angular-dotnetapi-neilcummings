using Microsoft.AspNetCore.Mvc;
using Udemy.Skinet.Api.Errors;

namespace Udemy.Skinet.Api.Controllers {
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController {
        public IActionResult Error(int code) {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Net;
using Udemy.Skinet.Api.Errors;
using Udemy.Skinet.Infrastructure.Data;

namespace Udemy.Skinet.Api.Controllers {
    public class BuggyController : BaseApiController {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context) {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest() {
            var thing = _context.Products.Find(42);

            if (thing == null) {
                return NotFound(new ApiResponse(HttpStatusCode.NotFound));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError() {
            var thing = _context.Products.Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest() {
            return BadRequest(new ApiResponse(HttpStatusCode.BadRequest));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id) {
            return Ok();
        }
    }
}

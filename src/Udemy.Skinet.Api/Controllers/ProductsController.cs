using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Udemy.Skinet.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<string> GetProducts() {
            return new string[] { "product1", "product2" };
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string GetProduct(int id) {
            return "single product";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}

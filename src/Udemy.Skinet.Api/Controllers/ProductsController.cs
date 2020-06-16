using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Infrastructure.Data;

namespace Udemy.Skinet.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context) {
            _context = context;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            var product = await _context.Products.FindAsync(id);
            return Ok(product);
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

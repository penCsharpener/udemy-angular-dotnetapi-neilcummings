using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Interfaces;
using Udemy.Skinet.Core.Specifications;

namespace Udemy.Skinet.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;
        private readonly IGenericRepository<ProductType> _productTypesRepo;

        public ProductsController(IGenericRepository<Product> productsRepo,
                                  IGenericRepository<ProductBrand> productBrandsRepo,
                                  IGenericRepository<ProductType> productTypesRepo) {
            _productsRepo = productsRepo;
            _productBrandsRepo = productBrandsRepo;
            _productTypesRepo = productTypesRepo;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() {
            var products = await _productsRepo.ListAsync(new ProductsWithTypesAndBrandsSpecification());
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands() {
            var brands = await _productBrandsRepo.ListAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes() {
            var types = await _productTypesRepo.ListAllAsync();
            return Ok(types);
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

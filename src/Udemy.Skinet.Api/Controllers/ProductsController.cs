﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Skinet.Api.Dtos;
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
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts() {
            var products = await _productsRepo.ListAsync(new ProductsWithTypesAndBrandsSpecification());
            return products.Select(product => {
                return new ProductToReturnDto {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    PictureUrl = product.PictureUrl,
                    Price = product.Price,
                    ProductBrand = product.ProductBrand.Name,
                    ProductType = product.ProductType.Name
                };
            }).ToList();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id) {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);

            return new ProductToReturnDto {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            };
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

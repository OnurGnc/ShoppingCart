using CartContract.Abstract;
using CartContract.Interface;
using CartData.Entity.Models;
using CartRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private Repository<Product> repository;

        public ProductController(Repository<Product> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = repository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = repository.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            repository.Create(product);
            repository.Save();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            repository.Update(product);
            repository.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            return Ok();
        }
    }
}

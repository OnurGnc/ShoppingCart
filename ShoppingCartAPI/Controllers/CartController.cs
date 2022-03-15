using CartBusiness.Interface;
using CartContract.Interface;
using CartData.Entity.Models;
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
    public class CartController : ControllerBase
    {
        private ICartProductManager manager;

        public CartController(ICartProductManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cartProducts = manager.GetCart();
            return Ok(cartProducts);
        }

        
        [HttpPost]
        [Route("addtocart")]
        public IActionResult AddToCart([FromBody] Product product)
        {
            var cardProducts = manager.AddToCart(product.Id);
            return Ok(cardProducts);
        }

        [HttpPost]
        [Route("updatecart")]
        public IActionResult UpdateCart([FromBody] Product product)
        {
            var cart = manager.UpdateCart(product);
            return Ok(cart);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Product product)
        {
            var test = manager.RemoveFromCart(product.Id);
            return Ok(test);
        }
    }
}

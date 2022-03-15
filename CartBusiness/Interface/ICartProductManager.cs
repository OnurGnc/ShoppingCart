using CartBusiness.DTO;
using CartData.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBusiness.Interface
{
    public interface ICartProductManager
    {
        public CartProductDTO AddToCart(int id);
        public CartProductDTO RemoveFromCart(int id);
        public CartProductDTO UpdateCart(Product cartProduct);
        public CartProductDTO GetCart();
    }
}

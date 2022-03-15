using CartContract.Abstract;
using CartData.Context;
using CartData.Entity.Models;
using CartRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartRepository.Repository
{
    public class CartProductRepository : Repository<CartProduct>, ICartProductRepository
    {
        public CartProductRepository(CartContext context) : base(context)
        {

        }

        public void DeleteByProductId(int id)
        {
            var cartProduct = GetByProductId(id);
            Delete(cartProduct.Id);
        }

        public CartProduct GetByProductId(int id)
        {
            return _context.Set<CartProduct>().Where(a => a.ProductId == id).FirstOrDefault();
        }
    }
}

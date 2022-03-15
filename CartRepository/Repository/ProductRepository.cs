using CartContract.Abstract;
using CartData.Context;
using CartData.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartRepository.Repository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(CartContext context) : base(context)
        {

        }
    }
}

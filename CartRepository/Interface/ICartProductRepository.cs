using CartData.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartRepository.Interface
{
    public interface ICartProductRepository
    {
        public CartProduct GetByProductId(int id);
        public void DeleteByProductId(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBusiness.DTO
{
    public class CartProductDTO
    {
        public CartProductDTO()
        {
            products = new List<ProductDTO>();
        }
        public decimal totalPrice { get; set; }
        public List<ProductDTO> products { get; set; }
    }
}

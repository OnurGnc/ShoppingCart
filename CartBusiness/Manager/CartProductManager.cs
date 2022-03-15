using CartBusiness.DTO;
using CartBusiness.Interface;
using CartContract.Abstract;
using CartData.Entity.Models;
using CartRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBusiness.Manager
{
    public class CartProductManager : ICartProductManager
    {
        private CartProductRepository cartRepo;
        private Repository<Product> productRepo;

        public CartProductManager(CartProductRepository cartRepo, Repository<Product> productRepo)
        {
            this.cartRepo = cartRepo;
            this.productRepo = productRepo;
        }

        public CartProductDTO AddToCart(int id)
        {
            var product = productRepo.GetById(id);
            if (product != null)
            {
                var cartProduct = cartRepo.GetByProductId(id);
                if (cartProduct != null && product.Quantity > cartProduct.Quantity)
                {
                    cartProduct.Quantity += 1;
                    cartRepo.Update(cartProduct);
                    cartRepo.Save();
                }
                else
                {
                    cartRepo.Create(new CartProduct { ProductId = id, Quantity = 1 });
                    cartRepo.Save();
                }
                return GetCart();
            }
            else
            {
                return null;
            }
        }

        public CartProductDTO RemoveFromCart(int productId)
        {
            var cartProduct = cartRepo.GetByProductId(productId);
            if (cartProduct != null)
            {
                cartRepo.DeleteByProductId(productId);
                cartRepo.Save();
                return GetCart();
            }
            return GetCart();
        }

        public CartProductDTO UpdateCart(Product product)
        {
            CartProduct cartProduct = cartRepo.GetByProductId(product.Id);
            cartProduct.Quantity = product.Quantity;

            cartRepo.Update(cartProduct);
            cartRepo.Save();

            return GetCart();
        }






        public CartProductDTO GetCart()
        {
            var cartProducts = cartRepo.GetAll();

            if (cartProducts != null)
            {
                CartProductDTO dto = new CartProductDTO();

                foreach (var cartProduct in cartProducts)
                {
                    var product = productRepo.GetById(cartProduct.ProductId);
                    dto.products.Add(new ProductDTO {
                        id = cartProduct.ProductId,
                        name = product.Name,
                        price = product.Price,
                        quantity= cartProduct.Quantity,
                        stock= product .Quantity
                    });
                    dto.totalPrice += product.Price * cartProduct.Quantity;
                }
                return dto;
            }
            else
            {
                return null;
            }
        }
    }
}

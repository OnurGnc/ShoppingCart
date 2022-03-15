using CartData.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartData.Context
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {

        }

        public DbSet<Product> Product;
        public DbSet<CartProduct> CartProduct;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");

            builder.Entity<CartProduct>(entity =>{

                entity.ToTable("CartProduct");

                entity.Property(a => a.ModifiedDate).HasDefaultValue(DateTime.Now);
                entity.Property(a => a.Quantity).IsRequired();
                entity.HasOne(a => a.Product)
                        .WithOne(b => b.CartProduct)
                        .HasForeignKey<CartProduct>(c => c.ProductId);
            });

            builder.Entity<Product>(entity => {

                entity.ToTable("Product");
            });
        }
    }
}

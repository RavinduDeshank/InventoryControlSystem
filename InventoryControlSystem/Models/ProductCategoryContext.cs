using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlSystem.Models
{
    public class ProductCategoryContext : DbContext
    {
        public ProductCategoryContext(DbContextOptions<ProductCategoryContext> options) : base(options)
        {

        }

        public DbSet<ProductCategory>ProductCategories { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}

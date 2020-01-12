using Microsoft.EntityFrameworkCore;
using Shop.Web.Model.Aggreagates;
using Shop.Web.Model.Entities;
using System.Reflection;

namespace Shop.Web.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Goods> CatalogItems { get; set; }
        public DbSet<GoodsBrand> CatalogBrands { get; set; }
        public DbSet<GoodsType> CatalogTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedItem> OrderItems { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

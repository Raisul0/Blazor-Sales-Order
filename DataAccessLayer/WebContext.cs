using DomainLayer.Entities.Locations;
using DomainLayer.Entities.Orders;
using DomainLayer.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }

        #region Products

        public DbSet<ElementType> ElementTypes { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<WindowElement> WindowElements { get; set; }

        #endregion

        #region Orders

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderWindow> OrderWindows { get; set; }

        #endregion

        #region Locations

        public DbSet<State> States { get; set; }

        #endregion

    }
}
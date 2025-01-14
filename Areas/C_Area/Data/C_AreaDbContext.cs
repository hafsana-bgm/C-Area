using C_Area.Areas.C_Area.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace C_Area.Areas.C_Area.Data
{
    public class C_AreaDbContext : IdentityDbContext
    {
        public C_AreaDbContext(DbContextOptions<C_AreaDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.

        }

        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Label> Label { get; set; } = default!;
    }
}

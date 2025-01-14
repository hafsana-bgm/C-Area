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
    }
}

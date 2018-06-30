using Microsoft.EntityFrameworkCore;
using BH.CyberQRiber.IdentityServer.Entities;

namespace BH.CyberQRiber.IdentityServer.Models
{
    public class BHCyberQRiberIdentityServerContext : DbContext
    {
        public BHCyberQRiberIdentityServerContext (DbContextOptions<BHCyberQRiberIdentityServerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<OnlineUser> OnlineUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BH.CyberQRiber.IdentityServer.Entities;

namespace BH.CyberQRiber.IdentityServer.Models
{
    public class BHCyberQRiberIdentityServerContext : DbContext
    {
        public BHCyberQRiberIdentityServerContext (DbContextOptions<BHCyberQRiberIdentityServerContext> options)
            : base(options)
        {
        }

        public DbSet<BH.CyberQRiber.IdentityServer.Entities.OnlineUser> OnlineUser { get; set; }
    }
}

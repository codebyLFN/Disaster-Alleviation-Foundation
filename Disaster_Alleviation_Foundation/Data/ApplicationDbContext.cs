using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Disaster_Alleviation_Foundation.Models;

namespace Disaster_Alleviation_Foundation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Disaster>? Disaster { get; set; }
        public DbSet<GoodsDonation>? GoodsDonation { get; set; }
        public DbSet<MonetaryDonation>? MonetaryDonation { get; set; }
        public DbSet<MonetaryAllocation>? MonetaryAllocation { get; set; }
        public DbSet<GoodsAllocation>? GoodsAllocation { get; set; }
        public DbSet<Purchase>? Purchase { get; set; }
    }
}

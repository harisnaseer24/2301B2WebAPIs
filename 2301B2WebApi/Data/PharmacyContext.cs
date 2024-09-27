using _2301B2WebApi.Models;

using Microsoft.EntityFrameworkCore;

namespace _2301B2WebApi.Data
{
    public class PharmacyContext : DbContext
    {

        public PharmacyContext(DbContextOptions<PharmacyContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Retailer> Retailers { get; set; }

        public virtual DbSet<Company> Companies { get; set; }


        public virtual DbSet<Medicine> Medicines { get; set; }
    }

 }
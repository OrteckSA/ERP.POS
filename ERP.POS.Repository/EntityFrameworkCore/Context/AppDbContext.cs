using ERP.POS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.POS.Repository.EntityFrameworkCore.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region Entities
        public virtual DbSet<TbCustomer> Customers { get; set; }
        public virtual DbSet<TbCustomerBranch> CustomerBranches { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=PosDemo; Trusted_Connection=True; TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

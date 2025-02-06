using ERP.POS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.POS.Repository.EntityFrameworkCore.Configrations.Customer
{
    internal class CustomerBranchConfigration : IEntityTypeConfiguration<CustomerBranch>
    {
        public void Configure(EntityTypeBuilder<CustomerBranch> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.CustomerBranches)
                .HasForeignKey(x => x.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

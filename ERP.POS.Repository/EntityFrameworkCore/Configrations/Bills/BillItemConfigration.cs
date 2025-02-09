using ERP.POS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.POS.Repository.EntityFrameworkCore.Configrations.Bills
{
    internal class BillItemConfigration : IEntityTypeConfiguration<BillItem>
    {
        public void Configure(EntityTypeBuilder<BillItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.BillId)
                .IsRequired();

            builder.Property(x => x.MaterialId)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.TaxRatio)
                .IsRequired();

            builder.HasOne(x => x.Bill)
                .WithMany(x => x.BillItems)
                .HasForeignKey(x => x.BillId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Material)
                .WithMany()
                .HasForeignKey(x => x.MaterialId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

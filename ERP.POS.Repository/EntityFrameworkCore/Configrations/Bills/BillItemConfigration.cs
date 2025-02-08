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
                .HasColumnType("REAL")
                .IsRequired();

            builder.Property(x => x.TaxRatio)
                .HasColumnType("REAL")
                .IsRequired();

            builder.OwnsOne(x => x.Discount, discount =>
            {
                discount.Property(x => x.Ratio)
                    .HasColumnName("DiscountRatio")
                    .HasColumnType("REAL")
                    .IsRequired();
                discount.Property(x => x.Value)
                    .HasColumnName("DiscountValue")
                    .HasColumnType("REAL")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.Extra, extra =>
            {
                extra.Property(x => x.Ratio)
                    .HasColumnName("ExtraRatio")
                    .HasColumnType("REAL")
                    .IsRequired();
                extra.Property(x => x.Value)
                    .HasColumnName("ExtraValue")
                    .HasColumnType("REAL")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.Measurement, measurement =>
            {
                measurement.Property(x => x.Unit)
                    .IsRequired()
                    .HasMaxLength(255);

                measurement.Property(x => x.UnitValue)
                    .HasColumnType("REAL")
                    .IsRequired();
            });

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

using ERP.POS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.POS.Repository.EntityFrameworkCore.Configrations.Bills
{
    internal class BillConfigration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StoreId)
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.CurrencyId)
                .IsRequired();

            builder.Property(x => x.CurrencyValue)
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

            builder.HasOne(x => x.Store)
                .WithMany()
                .HasForeignKey(x => x.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Currency)
                .WithMany()
                .HasForeignKey(x => x.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.BillItems)
                .WithOne(x => x.Bill)
                .HasForeignKey(x => x.BillId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

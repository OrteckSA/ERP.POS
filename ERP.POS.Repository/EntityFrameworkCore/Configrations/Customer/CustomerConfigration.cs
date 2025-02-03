﻿using ERP.POS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.POS.Repository.EntityFrameworkCore.Configrations.Customer
{
    internal class CustomerConfigration : IEntityTypeConfiguration<TbCustomer>
    {
        public void Configure(EntityTypeBuilder<TbCustomer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.LatinName)
                .HasMaxLength(255);

            builder.Property(x => x.MaximumSales)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.HasMany(x => x.CustomerBranches)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Customers");
        }
    }
}

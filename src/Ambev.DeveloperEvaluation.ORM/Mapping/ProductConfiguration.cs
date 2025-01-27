using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.Title).HasMaxLength(120).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Category).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();

            builder.HasMany(x => x.SalesItems)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}

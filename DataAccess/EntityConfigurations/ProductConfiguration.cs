using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class ProductConfiguration
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.CategoryId).HasColumnName("CategoryId").IsRequired();
            builder.Property(b => b.ProductName).HasColumnName("ProductName").IsRequired();
            builder.Property(b => b.UnitPrice).HasColumnName("UnitPrice").IsRequired(); 
            builder.Property(b => b.UnitsInStock).HasColumnName("UnitsInStock").IsRequired(); 
            builder.Property(b => b.QuantityPerUnit).HasColumnName("QuantityPerUnit").IsRequired();


            builder.HasIndex(indexExpression: b => b.ProductName, name: "UK_Categories_Name").IsUnique();

            builder.HasMany(b => b.Category);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}

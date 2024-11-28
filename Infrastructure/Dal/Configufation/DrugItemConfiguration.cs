using System.Xml;
using DrugsApt.Domain.Entities;
using DrugsApt.Infrastructure.Decorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugsApt.Infrastructure.Dal.Configufation;

public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        builder.HasKey(d => d.Id)
            .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<DrugItem>(nameof(DrugItem.Id)));

        builder.Property(di => di.Price)
            .IsRequired()
            .HasPrecision(10, 2)
           .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<DrugItem>(nameof(DrugItem.Price)));

           builder.Property(di => di.Amount)
               .IsRequired()
               .HasMaxLength(5)
            .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<DrugItem>(nameof(DrugItem.Amount)));

            builder.Property(di => di.DrugId)
                .IsRequired()
            .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<DrugItem>(nameof(DrugItem.DrugId)));

            builder.Property(di => di.DrugStoreId)
           .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<DrugItem>(nameof(DrugItem.DrugStoreId)));

           builder.HasOne(di => di.Drug)
               .WithMany(di => di.DrugItems)
               .HasForeignKey(di => di.DrugId)
            .IsRequired();

        builder.HasOne(di => di.DrugStore)
            .WithMany(di =>di.DrugItems)
            .HasForeignKey(di=> di.DrugStoreId);
    }
}
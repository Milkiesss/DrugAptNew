using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using DrugsApt.Infrastructure.Decorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DrugsApt.Infrastructure.Dal.Configufation;
/// <summary>
/// конфигурация DrugStore
/// </summary>
public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        builder.HasKey(ds => ds.Id)
            .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<DrugItem>(nameof(DrugStore.Id)));

        builder.Property(ds => ds.DrugNetwork)
            .IsRequired()
            .HasMaxLength(100)
            .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<DrugItem>(nameof(DrugStore.DrugNetwork)));

        builder.Property(ds => ds.Number)
            .IsRequired();
        builder.OwnsOne(ds => ds.Address, address =>
        {
            address.Property(ds => ds.City)
                .IsRequired()
                .HasMaxLength(50)
                .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<Address>(nameof(Address.City)));

            address.Property(ds => ds.Street)
                .IsRequired()
                .HasMaxLength(100)
                .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<Address>(nameof(Address.Street)));

            address.Property(ds => ds.House)
                .IsRequired()
                .HasAnnotation("Сomment",  (string)XmlDocumentation.GetXmlComments<Address>(nameof(Address.House)));

            address.Property(ds => ds.PostalCode)
                .IsRequired()
                .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<Address>(nameof(Address.PostalCode)));
        });

        builder.Property(ds => ds.PhoneNumber)
            .IsRequired()
            .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<DrugStore>(nameof(DrugStore.PhoneNumber)));
        
        builder.HasMany(ds => ds.DrugItems)
            .WithOne(ds => ds.DrugStore)
            .HasForeignKey(ds => ds.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
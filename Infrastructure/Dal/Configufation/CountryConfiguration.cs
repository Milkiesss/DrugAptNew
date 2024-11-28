using DrugsApt.Domain.Entities;
using DrugsApt.Infrastructure.Decorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugsApt.Infrastructure.Dal.Configufation;
/// <summary>
/// конфигурация Cuntry
/// </summary>
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{

    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.Id)
            .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<Country>(nameof(Country.Id)));

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
            .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<Country>(nameof(Country.Name)));

            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(10)
            .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<Country>(nameof(Country.Code)));
    }
}
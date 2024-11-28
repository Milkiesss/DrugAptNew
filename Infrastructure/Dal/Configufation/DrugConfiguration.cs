using DrugsApt.Domain.Entities;
using DrugsApt.Infrastructure.Decorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugsApt.Infrastructure.Dal.Configufation;
/// <summary>
/// Конфигурация Drug
/// </summary>
public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.HasKey(c=>c.Id);
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150)
            .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<Drug>(nameof(Drug.Name)));

        builder.Property(c => c.Manufacturer)
            .IsRequired()
            .HasMaxLength(100)
            .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<Drug>(nameof(Drug.Manufacturer)));

        builder.Property(c => c.CountryCodeId)
            .IsRequired()
            .HasMaxLength(3)
            .HasAnnotation("Comment", (string)XmlDocumentation.GetXmlComments<Drug>(nameof(Drug.CountryCodeId)));


        builder.HasMany(d => d.DrugItems)
            .WithOne(d => d.Drug)
            .HasForeignKey(d => d.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
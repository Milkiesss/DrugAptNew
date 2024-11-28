using System.Xml;
using DrugsApt.Domain.Entities;
using DrugsApt.Infrastructure.Decorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugsApt.Infrastructure.Dal.Configufation;
/// <summary>
/// Конфигурацяи FavoriteDrug
/// </summary>
public class FavoriteDrugConfiguration : IEntityTypeConfiguration<FavoriteDrug>
{
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
       builder.HasKey(fd=>fd.Id)
           .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<FavoriteDrug>(nameof(FavoriteDrug.Id)));
       
       builder.Property(fd => fd.ProfileId)
           .IsRequired()
           .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<FavoriteDrug>(nameof(FavoriteDrug.ProfileId)));

       builder.Property(fd => fd.DrugStoreId)
           .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<FavoriteDrug>(nameof(FavoriteDrug.DrugStoreId)));

       builder.Property(fd => fd.DrugId)
           .IsRequired()
           .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<FavoriteDrug>(nameof(FavoriteDrug.DrugId)));
        
       builder.HasOne(fd => fd.Drug)
           .WithMany()
           .HasForeignKey(fd => fd.DrugId)
           .OnDelete(DeleteBehavior.Cascade);
       
       builder.HasOne(fd => fd.DrugStore)
           .WithMany()
           .HasForeignKey(fd => fd.DrugStoreId)
           .OnDelete(DeleteBehavior.Cascade);
        
       builder.HasOne(fd => fd.Profile)
           .WithMany()
           .HasForeignKey(fd => fd.ProfileId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using DrugsApt.Infrastructure.Decorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugsApt.Infrastructure.Dal.Configufation;
/// <summary>
/// Конфигцрация Profile
/// </summary>
public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.HasKey(p => p.Id)
           .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<Profile>(nameof(Profile.Id)));

           builder.Property(p => p.ExteranlId)
               .IsRequired()
               .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<Profile>(nameof(Profile.ExteranlId)));

           builder.OwnsOne(s => s.Email, email =>
           {
               email.Property(p => p.Email)
                   .IsRequired()
                   .HasAnnotation("Сomment", (string)XmlDocumentation.GetXmlComments<EmailAddress>(nameof(EmailAddress.Email)));
           });
        
        builder.HasMany(p => p.FavoriteDrugs)
            .WithOne(p => p.Profile)
            .HasForeignKey(p => p.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
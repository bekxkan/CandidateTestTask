using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sigma.DAL.Entities.User;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Email);

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(500);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(500);

        builder
            .Property(x => x.PhoneNumber)
            .HasMaxLength(500);

        builder
            .Property(x => x.Email)
            .HasMaxLength(500);
        
        builder
            .Property(x => x.LinkedInUrl)
            .HasMaxLength(500);

        builder
            .Property(x => x.GitHubUrl)
            .HasMaxLength(500);
        
        builder
            .Property(x => x.FreeTextComment)
            .HasMaxLength(5000);
    }
}

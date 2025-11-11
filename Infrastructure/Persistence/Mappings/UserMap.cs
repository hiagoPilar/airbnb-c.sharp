using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using airbnb_c_.Domain.Entities;

namespace airbnb_c_.Infrastructure.Persistence.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //table name
            builder.ToTable("Users");

            //PK
            builder.HasKey(u => u.Id);

            //generate GUID on domain
            builder.Property(u => u.Id).ValueGeneratedNever();

            //account status
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.IsEmailVerified).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.UpdatedAt).IsRequired(false);


            //value objects
            builder.OwnsOne(u => u.Name, n =>
            {
                n.Property(p => p.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("FirstName")
                    .IsRequired();

                n.Property(p => p.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("LastName")
                    .IsRequired();
            });

            builder.OwnsOne(u => u.Email, e =>
            {
                e.Property(p => p.Address)
                    .HasMaxLength(200)
                    .HasColumnName("Email")
                    .IsRequired();
            });

            builder.OwnsOne(u => u.Password, p =>
            {
                p.Property(pw => pw.Value)
                    .HasColumnName("Password")
                    .IsRequired();
            });

            builder.OwnsOne(u => u.PhoneNumber, pn =>
            {
                pn.Property(p => p.Number)
                    .HasMaxLength(20)
                    .HasColumnName("PhoneNumber")
                    .IsRequired();
            });

            //enum role
            builder.Property(u => u.Role)
                .HasConversion<int>()
                .IsRequired();

            //add profile fields
            builder.Property(u => u.ProfilePictureUrl)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(u => u.Bio)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(u => u.Language)
                .HasMaxLength(10)
                .IsRequired(false);

            //advanced auth
            builder.Property(u => u.TwoFactorEnabled)
                .IsRequired();

            builder.Property(u => u.TwoFactorType)
                .HasConversion<int>()
                .IsRequired();

            //recovery password fields
            builder.Property(u => u.PasswordResetToken)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(u => u.PasswordResetTokenExpiration)
                .IsRequired(false);
        }
    }
}

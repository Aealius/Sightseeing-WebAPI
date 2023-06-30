using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId).HasName("PRIMARY");

            builder.ToTable("aspnetusers");

            builder.HasIndex(e => e.UserId, "Id").IsUnique();

            //builder.HasIndex(e => e.RoleId, "userRoleID_FK");

            builder.Property(e => e.UserId).HasColumnName("Id");
            builder.Property(e => e.Email)
                .HasColumnType("mediumtext")
                .HasColumnName("Email");
            builder.Property(e => e.Nickname)
                .HasColumnType("tinytext")
                .HasColumnName("UserName");
            builder.Property(e => e.Password)
                .HasColumnType("mediumtext")
                .HasColumnName("PasswordHash");
            //builder.Property(e => e.RoleId).HasColumnName("roleID");

            /*builder.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("userRoleID_FK");*/
        }
    }
}

using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class RoleConfiguration: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.RoleId).HasName("PRIMARY");

            builder.ToTable("role");

            builder.HasIndex(e => e.RoleId, "roleID").IsUnique();

            builder.Property(e => e.RoleId).HasColumnName("roleID");
            builder.Property(e => e.Name)
                .HasColumnType("tinytext")
                .HasColumnName("name");
        }
    }
}

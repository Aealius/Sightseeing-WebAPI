using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class GuideConfiguration : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> builder)
        {
            builder.HasKey(e => e.GuideId).HasName("PRIMARY");

            builder.ToTable("guide");

            builder.HasIndex(e => e.GuideId, "gID").IsUnique();

            builder.Property(e => e.GuideId).HasColumnName("gID");
            builder.Property(e => e.Name)
                .HasColumnType("mediumtext")
                .HasColumnName("name");
            builder.Property(e => e.PhoneNum)
                .HasColumnType("tinytext")
                .HasColumnName("phoneNum");
            builder.Property(e => e.Surname)
                .HasColumnType("mediumtext")
                .HasColumnName("surname");
        }
    }
}

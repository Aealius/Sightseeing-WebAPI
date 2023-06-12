using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class SightConfiguration : IEntityTypeConfiguration<Sight>
    {
        public void Configure(EntityTypeBuilder<Sight> builder)
        {
            builder.HasKey(e => e.SightId).HasName("PRIMARY");

            builder.ToTable("sight");

            builder.HasIndex(e => e.SightId, "sightID").IsUnique();

            builder.Property(e => e.SightId).HasColumnName("sightID");
            builder.Property(e => e.City)
                .HasColumnType("mediumtext")
                .HasColumnName("city");
            builder.Property(e => e.Name)
                .HasColumnType("mediumtext")
                .HasColumnName("name");
            builder.Property(e => e.Note)
                .HasColumnType("mediumtext")
                .HasColumnName("note");
            builder.Property(e => e.Street)
                .HasColumnType("mediumtext")
                .HasColumnName("street");
            builder.Property(e => e.StreetNum)
                .HasColumnType("mediumtext")
                .HasColumnName("streetNum");
            builder.Property(e => e.Zip)
                .HasColumnType("tinytext")
                .HasColumnName("ZIP");
        }
    }
}

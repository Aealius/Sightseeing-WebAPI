using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(e => e.TourId).HasName("PRIMARY");

            builder.ToTable("tour");

            builder.HasIndex(e => e.TourId, "tourID").IsUnique();

            builder.Property(e => e.TourId).HasColumnName("tourID");
            builder.Property(e => e.Price).HasColumnName("price");
        }
    }
}

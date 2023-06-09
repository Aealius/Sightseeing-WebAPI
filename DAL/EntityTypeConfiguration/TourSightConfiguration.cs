using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class TourSightConfiguration : IEntityTypeConfiguration<TourSight>
    {
        public void Configure(EntityTypeBuilder<TourSight> builder)
        {
            builder.HasKey(ts => new { ts.TourId, ts.SightId });

            builder.HasOne(p => p.Tour)
                  .WithMany(ts => ts.TourSights)
                  .HasForeignKey(g => g.TourId);

            builder.HasOne(p => p.Sight)
                  .WithMany(gt => gt.TourSights)
                  .HasForeignKey(t => t.SightId);

            builder.ToTable("toursight");
        }
    }
}

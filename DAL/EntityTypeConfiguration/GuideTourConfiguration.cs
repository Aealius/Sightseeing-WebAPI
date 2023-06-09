using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class GuideTourConfiguration : IEntityTypeConfiguration<GuideTour>
    {
        public void Configure(EntityTypeBuilder<GuideTour> builder)
        {
            builder.HasKey(gt => new { gt.GuideId, gt.TourId });

            builder.HasOne(p => p.Guide)
                  .WithMany(gt => gt.GuideTours)
                  .HasForeignKey(g => g.GuideId);

            builder.HasOne(p => p.Tour)
                  .WithMany(gt => gt.GuideTours)
                  .HasForeignKey(t => t.TourId);

            builder.ToTable("guidetour");
        }
    }
}

using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(e => e.ReviewId).HasName("PRIMARY");

            builder.ToTable("review");

            builder.HasIndex(e => e.ReviewId, "reviewID").IsUnique();

            builder.HasIndex(e => e.SightId, "reviewSightID_FK");

            builder.HasIndex(e => e.UserId, "reviewUserID_FK");

            builder.Property(e => e.ReviewId).HasColumnName("reviewID");
            builder.Property(e => e.Mark).HasColumnName("mark");
            builder.Property(e => e.SightId).HasColumnName("sightID");
            builder.Property(e => e.Text)
                .HasColumnType("mediumtext")
                .HasColumnName("text");
            builder.Property(e => e.UserId).HasColumnName("userID");

            builder.HasOne(d => d.Sight).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.SightId)
                .HasConstraintName("reviewSightID_FK");

            builder.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("reviewUserID_FK");
        }
    }
}

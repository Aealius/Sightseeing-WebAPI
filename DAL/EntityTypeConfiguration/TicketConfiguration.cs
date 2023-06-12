using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfigurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(e => e.TicketId).HasName("PRIMARY");

            builder.ToTable("ticket");

            builder.HasIndex(e => e.TicketId, "ticketID").IsUnique();

            builder.HasIndex(e => e.TourId, "ticketTourID_FK");

            builder.HasIndex(e => e.UserId, "ticketUserID_FK");

            builder.Property(e => e.TicketId).HasColumnName("ticketID");
            builder.Property(e => e.TicketDate)
                .HasColumnType("date")
                .HasColumnName("ticketDate");
            builder.Property(e => e.TourId).HasColumnName("tourID");
            builder.Property(e => e.UserId).HasColumnName("userID");

            builder.HasOne(d => d.Tour).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("ticketTourID_FK");

            builder.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("ticketUserID_FK");
        }
    }
}

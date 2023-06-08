using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class SightseeingdbContext : DbContext
{
    public SightseeingdbContext()
    {
    }

    public SightseeingdbContext(DbContextOptions<SightseeingdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sight> Sights { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseMySQL("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GuideTour>(entity =>
        {
            entity.HasKey(gt=> new {gt.GuideId,gt.TourId});

            entity.HasOne(p => p.Guide)
                  .WithMany(gt => gt.GuideTours)
                  .HasForeignKey(g => g.GuideId);

            entity.HasOne(p => p.Tour)
                  .WithMany(gt => gt.GuideTours)
                  .HasForeignKey(t => t.TourId);

            entity.ToTable("guidetour");
        });

        modelBuilder.Entity<TourSight>(entity =>
        {
            entity.HasKey(ts => new { ts.TourId, ts.SightId });

            entity.HasOne(p => p.Tour)
                  .WithMany(ts => ts.TourSights)
                  .HasForeignKey(g => g.TourId);

            entity.HasOne(p => p.Sight)
                  .WithMany(gt => gt.TourSights)
                  .HasForeignKey(t => t.SightId);

            entity.ToTable("toursight");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.GId).HasName("PRIMARY");

            entity.ToTable("guide");

            entity.HasIndex(e => e.GId, "gID").IsUnique();

            entity.Property(e => e.GId).HasColumnName("gID");
            entity.Property(e => e.Name)
                .HasColumnType("mediumtext")
                .HasColumnName("name");
            entity.Property(e => e.PhoneNum)
                .HasColumnType("tinytext")
                .HasColumnName("phoneNum");
            entity.Property(e => e.Surname)
                .HasColumnType("mediumtext")
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PRIMARY");

            entity.ToTable("review");

            entity.HasIndex(e => e.ReviewId, "reviewID").IsUnique();

            entity.HasIndex(e => e.SightId, "reviewSightID_FK");

            entity.HasIndex(e => e.UserId, "reviewUserID_FK");

            entity.Property(e => e.ReviewId).HasColumnName("reviewID");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.SightId).HasColumnName("sightID");
            entity.Property(e => e.Text)
                .HasColumnType("mediumtext")
                .HasColumnName("text");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Sight).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.SightId)
                .HasConstraintName("reviewSightID_FK");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("reviewUserID_FK");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("role");

            entity.HasIndex(e => e.RoleId, "roleID").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("roleID");
            entity.Property(e => e.Name)
                .HasColumnType("tinytext")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sight>(entity =>
        {
            entity.HasKey(e => e.SightId).HasName("PRIMARY");

            entity.ToTable("sight");

            entity.HasIndex(e => e.SightId, "sightID").IsUnique();

            entity.Property(e => e.SightId).HasColumnName("sightID");
            entity.Property(e => e.City)
                .HasColumnType("mediumtext")
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasColumnType("mediumtext")
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasColumnType("mediumtext")
                .HasColumnName("note");
            entity.Property(e => e.Street)
                .HasColumnType("mediumtext")
                .HasColumnName("street");
            entity.Property(e => e.StreetNum)
                .HasColumnType("mediumtext")
                .HasColumnName("streetNum");
            entity.Property(e => e.Zip)
                .HasColumnType("tinytext")
                .HasColumnName("ZIP");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PRIMARY");

            entity.ToTable("ticket");

            entity.HasIndex(e => e.TicketId, "ticketID").IsUnique();

            entity.HasIndex(e => e.TourId, "ticketTourID_FK");

            entity.HasIndex(e => e.UserId, "ticketUserID_FK");

            entity.Property(e => e.TicketId).HasColumnName("ticketID");
            entity.Property(e => e.TicketDate)
                .HasColumnType("date")
                .HasColumnName("ticketDate");
            entity.Property(e => e.TourId).HasColumnName("tourID");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Tour).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("ticketTourID_FK");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("ticketUserID_FK");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.TourId).HasName("PRIMARY");

            entity.ToTable("tour");

            entity.HasIndex(e => e.TourId, "tourID").IsUnique();

            entity.Property(e => e.TourId).HasColumnName("tourID");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.UserId, "userID").IsUnique();

            entity.HasIndex(e => e.RoleId, "userRoleID_FK");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Email)
                .HasColumnType("mediumtext")
                .HasColumnName("email");
            entity.Property(e => e.Nickname)
                .HasColumnType("tinytext")
                .HasColumnName("nickname");
            entity.Property(e => e.Password)
                .HasColumnType("mediumtext")
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("roleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("userRoleID_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

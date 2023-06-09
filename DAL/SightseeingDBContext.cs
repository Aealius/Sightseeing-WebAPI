using DAL.Entities;
using DAL.EntitiesConfigurations;
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
        modelBuilder.ApplyConfiguration(new GuideTourConfiguration());

        modelBuilder.ApplyConfiguration(new TourSightConfiguration());

        modelBuilder.ApplyConfiguration(new GuideConfiguration());

        modelBuilder.ApplyConfiguration(new ReviewConfiguration());

        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        modelBuilder.ApplyConfiguration(new SightConfiguration());

        modelBuilder.ApplyConfiguration(new TicketConfiguration());

        modelBuilder.ApplyConfiguration(new TourConfiguration());   

        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}

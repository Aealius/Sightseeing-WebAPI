namespace DAL.Entities;

public class Tour
{
    public uint TourId { get; set; }
    public uint Price { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    public ICollection<GuideTour> GuideTours { get; set; }
    public ICollection<TourSight> TourSights { get; set; }
}

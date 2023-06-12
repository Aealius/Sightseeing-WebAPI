namespace DAL.Entities;

public class Ticket
{
    public uint TicketId { get; set; }
    public uint TourId { get; set; }
    public DateTime TicketDate { get; set; }
    public uint UserId { get; set; }
    public Tour Tour { get; set; } = null!;
    public User User { get; set; } = null!;
}

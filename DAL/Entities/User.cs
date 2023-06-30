namespace DAL.Entities;

public class User : User_Registr
{
    public string UserId { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public Role Role { get; set; } = null!;
    public ICollection<Ticket> Tickets { get; set; }
}

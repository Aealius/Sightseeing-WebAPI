namespace DAL.Entities;

public class User
{
    public uint UserId { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public uint RoleId { get; set; }
    public string Nickname { get; set; } = null!;
    public ICollection<Review> Reviews { get; set; }
    public Role Role { get; set; } = null!;
    public ICollection<Ticket> Tickets { get; set; }
}

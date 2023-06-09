namespace DAL.Entities;

public class Review
{
    public uint ReviewId { get; set; }
    public string? Text { get; set; }
    public byte Mark { get; set; }
    public uint UserId { get; set; }
    public uint SightId { get; set; }
    public Sight Sight { get; set; } = null!;
    public User User { get; set; } = null!;
}

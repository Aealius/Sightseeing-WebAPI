namespace DAL.Entities;

public class Guide
{
    public uint GuideId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string PhoneNum { get; set; } = null!;
    public ICollection<GuideTour> GuideTours { get; set; } 
}

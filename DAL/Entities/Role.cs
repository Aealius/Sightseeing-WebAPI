namespace DAL.Entities;

public class Role
{
    public uint RoleId { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<User> Users { get; set; } = new List<User>();
}

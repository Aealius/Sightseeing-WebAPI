using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class User
{
    public uint UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public uint RoleId { get; set; }

    public string Nickname { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; }
}

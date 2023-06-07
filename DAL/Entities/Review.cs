using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Review
{
    public uint ReviewId { get; set; }

    public string? Text { get; set; }

    public byte Mark { get; set; }

    public uint UserId { get; set; }

    public uint SightId { get; set; }

    public virtual Sight Sight { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

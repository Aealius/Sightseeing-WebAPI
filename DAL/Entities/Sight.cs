using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Sight
{
    public uint SightId { get; set; }

    public string? Note { get; set; }

    public string City { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string StreetNum { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; }

    public virtual ICollection<TourSight> TourSights { get; set; }
}

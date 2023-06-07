using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Tour
{
    public uint TourId { get; set; }

    public uint Price { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; }

    public virtual ICollection<GuideTour> GuideTours { get; set; }

    public virtual ICollection<TourSight> TourSights { get; set; }
}

using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Ticket
{
    public uint TicketId { get; set; }

    public uint TourId { get; set; }

    public DateTime TicketDate { get; set; }

    public uint UserId { get; set; }

    public virtual Tour Tour { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Guide
{
    public uint GId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string PhoneNum { get; set; } = null!;

    public ICollection<GuideTour> GuideTours { get; set; } 
}

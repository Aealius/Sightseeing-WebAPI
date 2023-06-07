using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TourSight
    {
        public uint TourId { get; set; }
        public uint SightId { get; set; }
        public Tour Tour { get; set; }
        public Sight Sight { get; set; }
    }
}

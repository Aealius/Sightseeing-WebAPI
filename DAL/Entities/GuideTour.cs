using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class GuideTour
    {
        public uint GuideId { get; set; }
        public uint TourId { get; set; }
        public Guide Guide { get; set; }
        public Tour Tour { get; set; }

    }
}

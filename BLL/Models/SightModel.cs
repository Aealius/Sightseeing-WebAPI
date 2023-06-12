using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class SightModel
    {
        public uint SightId { get; set; }
        public string? Note { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; } 
        public string StreetNum { get; set; } 
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class ReviewModel
    {
        public uint ReviewId { get; set; }
        public string? Text { get; set; }
        public byte Mark { get; set; }
        public uint UserId { get; set; }
        public uint SightId { get; set; }
    }
}

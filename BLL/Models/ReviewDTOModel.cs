using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class ReviewDTOModel
    {
        public uint ReviewId { get; set; }
        public string? Text { get; set; }
        [RegularExpression(@"^[0-9](,)[0-9]|10,0", ErrorMessage = "Invalid Data Type")]
        public byte Mark { get; set; }
        public uint UserId { get; set; }
        public uint SightId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class SightDTOModel
    {
        public uint SightId { get; set; }
        [RegularExpression(@"^[0-9](,)[0-9]|10,0", ErrorMessage = "Invalid Data Type")]
        public string? Note { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; } 
        public string StreetNum { get; set; } 
        public string Name { get; set; }
    }
}

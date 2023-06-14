using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class TourDTOModel
    {
        public uint TourId { get; set; }
        [RegularExpression(@"^\d+(,\d{1,2})?$", ErrorMessage = "Invalid Data Type")]
        public uint Price { get; set; }
    }
}

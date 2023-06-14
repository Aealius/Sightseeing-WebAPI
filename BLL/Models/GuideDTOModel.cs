using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class GuideDTOModel
    {
        public uint GuideId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [RegularExpression(@"^\+375(17|29|33|44)[0-9]{7}$", ErrorMessage = "Invalid Data Type")]
        public string PhoneNum { get; set; }
    }
}

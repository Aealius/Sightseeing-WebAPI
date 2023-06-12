using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class TicketModel
    {
        public uint TicketId { get; set; }
        public uint TourId { get; set; }
        [RegularExpression(@"(0?[1-9]|[12][0-9]|3[01])(.)(0?[1-9]|1[012])(.)((19|20)\d\d)", ErrorMessage = "Invalid Data Type")]
        public DateTime TicketDate { get; set; }
        public uint UserId { get; set; }
    }
}

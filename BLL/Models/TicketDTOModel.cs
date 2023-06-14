using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class TicketDTOModel
    {
        public uint TicketId { get; set; }
        public uint TourId { get; set; }
        public DateTime TicketDate { get; set; }
        public uint UserId { get; set; }
    }
}

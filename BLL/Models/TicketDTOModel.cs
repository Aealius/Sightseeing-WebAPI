namespace BLL.Models
{
    public class TicketDTOModel
    {
        public uint TicketId { get; set; }
        public uint TourId { get; set; }
        public DateTime TicketDate { get; set; }
        public string UserId { get; set; }
    }
}

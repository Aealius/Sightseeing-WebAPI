namespace BLL.Models
{
    public class ReviewDTOModel
    {
        public uint ReviewId { get; set; }
        public string? Text { get; set; }
        public string? Mark { get; set; }
        public string UserId { get; set; }
        public uint SightId { get; set; }
    }
}

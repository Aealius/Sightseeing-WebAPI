namespace BLL.Models
{
    public class SightDTOModel
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

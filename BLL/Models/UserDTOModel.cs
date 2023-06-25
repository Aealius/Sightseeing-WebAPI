namespace BLL.Models
{
    public class UserDTOModel
    {
        public uint UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public uint RoleId { get; set; }
        public string Nickname { get; set; }
    }
}

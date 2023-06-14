using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class UserDTOModel
    {
        public uint UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public uint RoleId { get; set; }
        public string Nickname { get; set; }
    }
}

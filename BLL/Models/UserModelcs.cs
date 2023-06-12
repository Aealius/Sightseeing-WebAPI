using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class UserModelcs
    {
        public uint UserId { get; set; }
        [RegularExpression(@"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d)(?=.*[^\da - zA - Z]).{8, 15}$", ErrorMessage = "Invalid Data Type! Password of 8 characters or more.")]
        public string Email { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Data Type")]
        public string Password { get; set; }
        public uint RoleId { get; set; }
        [RegularExpression(@"\A[^\d_]+\z", ErrorMessage = "Invalid Data Type")]
        public string Nickname { get; set; }
    }
}

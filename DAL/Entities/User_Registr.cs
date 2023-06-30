using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User_Registr : User_Auth
    {
        public string Nickname { get; set; } = null!;
        public uint RoleId { get; set; }
    }
}

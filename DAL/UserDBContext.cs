using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class UserDBContext : IdentityDbContext<IdentityUser>
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options) 
        { 
            Database.EnsureCreated();
        }
    }
}

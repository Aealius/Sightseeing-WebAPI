using BLL.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    internal class UserValidator : AbstractValidator<UserDTOModel>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserId).NotNull();
            RuleFor(u => u.RoleId).NotNull();
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Password).NotEmpty().Length(8, 15);
            RuleFor(u => u.Nickname).NotEmpty();    
        }
    }
}

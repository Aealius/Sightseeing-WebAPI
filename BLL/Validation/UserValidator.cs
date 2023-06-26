using BLL.Models;
using FluentValidation;

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

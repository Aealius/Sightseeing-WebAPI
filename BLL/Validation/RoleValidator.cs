using BLL.Models;
using FluentValidation;

namespace BLL.Validation
{
    internal class RoleValidator : AbstractValidator<RoleDTOModel>
    {
        public RoleValidator()
        {
            RuleFor(r => r.RoleId).NotNull();
            RuleFor(r => r.Name).NotEmpty();
        }
    }
}

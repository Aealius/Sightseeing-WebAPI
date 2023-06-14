using BLL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

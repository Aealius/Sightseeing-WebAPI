using BLL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Validation
{
    internal class SightValidator : AbstractValidator<SightDTOModel>
    {
        public SightValidator()
        {
            RuleFor(s => s.SightId).NotNull();
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Street).NotEmpty();
            RuleFor(s => s.StreetNum).NotEmpty();
            RuleFor(s => s.Note).NotNull()
                .Matches(new Regex(@"^[0-9](,)[0-9]|10,0"));
            RuleFor(s => s.Zip).NotEmpty();
            RuleFor(s => s.City).NotEmpty();
        }
    }
}

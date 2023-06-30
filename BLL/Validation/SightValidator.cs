using BLL.Models;
using FluentValidation;
using System.Text.RegularExpressions;

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

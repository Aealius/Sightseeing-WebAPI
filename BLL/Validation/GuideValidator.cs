using BLL.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BLL.Validation
{
    internal class GuideValidator : AbstractValidator<GuideDTOModel>
    {
        public GuideValidator()
        {
            RuleFor(g => g.GuideId).NotNull();
            RuleFor(g => g.PhoneNum).NotEmpty()
                .Length(13)
                .Matches(new Regex(@"^\+375(17|29|33|44)[0-9]{7}$"));
            RuleFor(g => g.Name).NotEmpty();
            RuleFor(g => g.Surname).NotEmpty();
        }
    }
}

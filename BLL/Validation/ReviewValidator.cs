using BLL.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BLL.Validation
{
    internal class ReviewValidator : AbstractValidator<ReviewDTOModel>
    {
        public ReviewValidator()
        {
            RuleFor(r => r.ReviewId).NotNull();
            RuleFor(r => r.UserId).NotNull();
            RuleFor(r => r.SightId).NotNull();
            RuleFor(r => r.Text).NotEmpty();
            RuleFor(r => r.Mark).NotNull()
                .Matches(new Regex(@"^[0-9](,)[0-9]|10,0"));
        }
    }
}

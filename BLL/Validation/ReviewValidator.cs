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

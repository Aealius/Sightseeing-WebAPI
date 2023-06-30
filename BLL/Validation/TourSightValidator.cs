using BLL.Models;
using FluentValidation;

namespace BLL.Validation
{
    internal class TourSightValidator : AbstractValidator<TourSightDTOModel>
    {
        public TourSightValidator()
        {
            RuleFor(ts => ts.TourId).NotNull();
            RuleFor(ts => ts.SightId).NotNull();
        }
    }
}

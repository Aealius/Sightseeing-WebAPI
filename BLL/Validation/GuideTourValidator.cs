using BLL.Models;
using FluentValidation;

namespace BLL.Validation
{
    internal class GuideTourValidator : AbstractValidator<GuideTourDTOModel>
    {
        public GuideTourValidator()
        {
            RuleFor(gt => gt.TourId).NotNull();
            RuleFor(gt => gt.GuideId).NotNull();
        }
    }
}

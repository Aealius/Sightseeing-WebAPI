using BLL.Models;
using FluentValidation;

namespace BLL.Validation
{
    internal class TourValidator : AbstractValidator<TourDTOModel>
    {
        public TourValidator()
        {
            RuleFor(t => t.TourId).NotNull();
            RuleFor(t => t.Price).NotNull().NotEmpty();
        }
    }
}

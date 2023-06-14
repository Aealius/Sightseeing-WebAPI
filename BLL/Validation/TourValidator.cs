using BLL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

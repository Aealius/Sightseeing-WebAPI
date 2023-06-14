using BLL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

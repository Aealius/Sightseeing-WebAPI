using BLL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

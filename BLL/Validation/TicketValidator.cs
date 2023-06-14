using BLL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    internal class TicketValidator : AbstractValidator<TicketDTOModel>
    {
        public TicketValidator()
        {
            RuleFor(t => t.TicketId).NotNull();
            RuleFor(t => t.UserId).NotNull();
            RuleFor(t => t.TourId).NotNull();
            RuleFor(t => t.TicketDate).NotEmpty()
                .InclusiveBetween(new DateTime(1971, 1, 1), DateTime.Now.AddYears(-10)); ;
        }
    }
}

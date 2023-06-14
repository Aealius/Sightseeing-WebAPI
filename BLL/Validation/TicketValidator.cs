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
            RuleFor(t => t.TicketDate).NotEmpty();
        }
    }
}

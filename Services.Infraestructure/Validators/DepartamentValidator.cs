using FluentValidation;
using Services.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infraestructure.Validators
{
    public class DepartamentValidator : AbstractValidator<DepartamentDTO>
    {
        public DepartamentValidator()
        {
            RuleFor(name => name.Name)

            .NotEmpty().WithMessage("campo obrigatório");

            RuleFor(name => name.Name)
                .NotNull()
                .NotEmpty().WithMessage("campo obrigatório");
            //.LessThan(p => DateTime.Now);


        }
    }
}

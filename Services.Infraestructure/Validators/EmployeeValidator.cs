using FluentValidation;
using Services.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infraestructure.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTOs>
    {
        public EmployeeValidator()
        {

            RuleFor(employee => employee.Name)

            .NotEmpty().WithMessage("campo obrigatório");

            RuleFor(employee => employee.Salary)
                .NotNull()
                .NotEmpty().WithMessage("campo obrigatório");
            //.LessThan(p => DateTime.Now);

            RuleFor(employee => employee.IdDepartament)
                .NotNull().WithMessage("Campo Obligatorio")
               .NotEmpty().WithMessage("campo obrigatório");
            //.InclusiveBetween(0, 24).WithMessage("Ingrese solo números");

            RuleFor(employee => employee.Email)
               .NotNull()

               .NotEmpty().WithMessage("campo obrigatório")
            .EmailAddress().WithMessage("email inválido")
            .OnAnyFailure(employee => employee.Email = "");
        }
    }
}

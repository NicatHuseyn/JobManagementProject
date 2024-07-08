using FluentValidation;
using KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.CreateIndustry;
using KormosalaWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Validators.IndustryValidator
{
    public class CreateIndustryValidator:AbstractValidator<CreateIndustryCommandRequest>
    {
        public CreateIndustryValidator()
        {
            RuleFor(i => i.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Enter your industry name")
                .Length(3, 20)
                .WithMessage("Please enter industry name between 3 and 20 charecters");
        }
    }
}

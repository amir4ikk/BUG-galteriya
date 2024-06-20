using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;
public class CompanyValidator : AbstractValidator<Company>
{
    public CompanyValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name bosh bolmasligi kerak")
            .Length(3, 40)
            .WithMessage("Name 3 va 40 belgi orasida bolishi kerak");
        RuleFor(x => x.Creator_Name)
            .NotEmpty()
            .WithMessage("Creator_Name bosh bolmasligi kerak");
        RuleFor(x => x.Employees_Count)
            .NotEmpty()
            .WithMessage("Birta Bo'lsa Ham Ishchi Bo'lishi Kerak");
    }
}

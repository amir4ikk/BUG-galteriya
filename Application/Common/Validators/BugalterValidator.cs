using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;
public class BugalterValidator : AbstractValidator<Bugalter>
{
    public BugalterValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name Bosh Bolmasligi Lozim");
        RuleFor(x => x.Company_Name)
            .NotEmpty()
            .WithMessage("Qayerda Dir Ishlashi Lozim");
    }
}

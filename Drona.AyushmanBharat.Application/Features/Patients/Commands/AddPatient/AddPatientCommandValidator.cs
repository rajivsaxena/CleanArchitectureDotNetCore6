using FluentValidation;

namespace Drona.AyushmanBharat.Application.Features.Patients.Commands.AddPatient
{
    public class AddPatientCommandValidator : AbstractValidator<AddPatientCommand>
    {
        public AddPatientCommandValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("{First Name is required.}")
                .NotNull()
                .MaximumLength(50).WithMessage("{FirstName} must not exceed 50 characters");
            RuleFor(r => r.LastName)
                .NotNull()
                .NotEmpty().WithMessage("{LastName} is required")
                .MaximumLength(50).WithMessage("{LastName} must not exceed 50 characters"); ;
            RuleFor(r => r.MobileNumber)
                .NotEmpty().WithMessage("{MobileNumber} is required.")
                .MaximumLength(10).WithMessage("{MobileNumber} must not exceed 10 characters");
        }
    }
}

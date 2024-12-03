using FluentValidation;
using LanguageCourse.API.DTOs;

namespace LanguageCourse.API.Validation
{
    public class CreateStudentValidation : AbstractValidator<CreateStudentDTO>
    {
        public CreateStudentValidation()
        {
            RuleFor(s => s.Name).NotEmpty().NotNull().WithMessage("O campo nome é obrigatório {PropertyName}");
            RuleFor(s => s.Email).NotEmpty()
                .EmailAddress().WithMessage("O campo Email deve ser um endereço de e-mail válido.")
                .NotNull().WithMessage("O campo E-mail é obrigatório {PropertyName}");
            RuleFor(s => s.CPF)
                .NotEmpty().WithMessage("O campo CPF é obrigatório.")
                .NotNull().WithMessage("O campo CPF é obrigatório.")
                .Must(Validator.IsValidCPF).WithMessage("O CPF informado não é válido.");

            RuleFor(s => s.Genre)
                .NotEmpty().WithMessage("O campo gênero é obrigatório.")
                .IsInEnum().WithMessage("O campo gênero deve conter um valor válido.");

        }
    }
}

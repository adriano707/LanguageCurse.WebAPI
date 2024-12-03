using FluentValidation;
using LanguageCourse.API.DTOs;

namespace LanguageCourse.API.Validation
{
    public class CreateClassValidation : AbstractValidator<CreateClasstDTO>
    {
        public CreateClassValidation()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty().WithMessage("O campo nome é obrigatório {PropertyName}");
        }
    }
}

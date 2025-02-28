using FluentValidation;

namespace MnemosyneAPI.Model.Validates
{
    public class MemoryValidator : AbstractValidator<Memory>
    {
        public MemoryValidator()
        {
            RuleFor(x => x.title)
                .NotNull().WithMessage("Titulo e obrigatorio")
                .Length(3, 100).WithMessage("O titulo deve ter de 3 a 100 caracteres");

            RuleFor(x => x.description)
                .NotNull().WithMessage("Descricao e obrigatoria")
                .NotEmpty().WithMessage("Descricao nao pode ser vazio");

            RuleFor(x => x.images)
                .NotNull().WithMessage("Imagem e obrigatoria")
                .NotEmpty().WithMessage("Imagem nao pode ser vazio");

        }
    }
}

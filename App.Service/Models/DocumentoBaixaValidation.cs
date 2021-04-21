using App.Domain.Models;
using FluentValidation;

namespace App.Service.Models
{
    public class DocumentoBaixaValidation : AbstractValidator<DocumentoBaixa>
    {
        public DocumentoBaixaValidation()
        {
            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}

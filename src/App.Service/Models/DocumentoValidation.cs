using App.Domain.Models;
using FluentValidation;

namespace App.Service.Models
{
    public class DocumentoValidation : AbstractValidator<Documento>
    {
        public DocumentoValidation()
        {
            RuleFor(x => x.IdPessoa)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(x => x.DataVencimento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}

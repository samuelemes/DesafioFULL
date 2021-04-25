using App.Domain.Models;
using FluentValidation;

namespace App.Service.Models
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(11).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");
        }
    }
}

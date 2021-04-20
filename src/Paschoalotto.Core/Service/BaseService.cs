using FluentValidation;
using Paschoalotto.Core.Models;

namespace Paschoalotto.Core.Service
{
    public abstract class BaseService
    {
        protected bool ExecutarValidacao<TV, TE>(TV Validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = Validacao.Validate(entidade);

            if (validator.IsValid) return true;

            return false;
        }
    }
}
using App.Core.Models;
using App.Core.Notificador;
using FluentValidation;

namespace App.Core.Service
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(FluentValidation.Results.ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
        protected bool ExecutarValidacao<TV, TE>(TV Validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = Validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}

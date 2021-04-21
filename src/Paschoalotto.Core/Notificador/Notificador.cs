using System.Collections.Generic;
using System.Linq;

namespace App.Core.Notificador
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacao;
        public Notificador()
        {
            _notificacao = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacao.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacao;
        }

        public bool TemNotificacao()
        {
            return _notificacao.Any();
        }
    }
}

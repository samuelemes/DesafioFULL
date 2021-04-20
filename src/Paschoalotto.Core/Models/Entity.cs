using System;

namespace Paschoalotto.Core.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public DateTimeOffset DataInclusao { get; set; } = DateTimeOffset.Now;
        public Guid IdUsuarioInclusao { get; set; }
        public DateTimeOffset DataAlteracao { get; set; }
        public Guid? IdUsuarioAlteracao { get; set; }
    }
}

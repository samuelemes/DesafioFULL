using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paschoalotto.Core.Models
{
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTimeOffset DataInclusao { get; set; } = DateTimeOffset.Now;
        public Guid IdUsuarioInclusao { get; set; }
        public DateTimeOffset DataAlteracao { get; set; }
        public Guid? IdUsuarioAlteracao { get; set; }
    }
}

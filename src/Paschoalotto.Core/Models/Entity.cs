using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models
{
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTimeOffset DataInclusao { get; set; } = DateTimeOffset.Now;
        public int IdUsuarioInclusao { get; set; } = 0;
        public DateTimeOffset? DataAlteracao { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
    }
}

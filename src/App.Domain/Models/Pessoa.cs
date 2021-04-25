using App.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Models
{
    public class Pessoa : Entity
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "varchar(11)")]
        public string Cpf { get; set; }
    }
}

using App.Core.Api.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace App.Api.ViewModels
{
    public class PessoaViewModel : BaseViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter {1} caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter {1} caracteres")]
        public string Cpf { get; set; }
    }
}

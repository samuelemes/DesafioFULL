using App.Core.Api.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace App.Api.ViewModels
{
    public class PessoaViewModel : BaseViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter {1} caracteres")]
        [Display(Name = "Nome do devedor")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter {1} à {2}caracteres"), MinLength(11)]
        [DisplayFormat(DataFormatString = "000\\.000\\.000-00")]
        [Display(Name = "Número do CPF")]
        public string Cpf { get; set; }
    }
}

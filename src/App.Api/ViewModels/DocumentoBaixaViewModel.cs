using App.Core.Api.ViewModels;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Api.ViewModels
{
    public class DocumentoBaixaViewModel : BaseViewModel
    {
        [DisplayName("Documento")]
        public int idDocumento { get; set; }


        [Required]
        [DisplayName("Data do Pagamento")]
        [DataType(DataType.Date)]
        public DateTimeOffset DataBaixa { get; set; }


        [Required]
        [DisplayName("Valor Pago")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }
        
        
        [DisplayName("Valor Desconto")]
        [DataType(DataType.Currency)]
        public decimal ValorDesconto { get; set; }


        public virtual DocumentoViewModel Documento { get; set; }
    }
}

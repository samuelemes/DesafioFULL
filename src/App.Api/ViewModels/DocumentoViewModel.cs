using App.Core.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Api.ViewModels
{
    public class DocumentoViewModel : BaseViewModel
    {
        public int? idDocumentoOrigem { get; set; }

        [Required]
        [DisplayName("Tipo Documento")]
        public TipoDocumentoViewModel TipoDocumento { get; set; }
        
        public DocumentoViewModel DocumentoOrigem { get; set; }

        public PessoaViewModel Pessoa { get; set; }


        [Required]
        [Display(Name = "Data de Vencimento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; } = DateTime.Now;

        [Display(Name = "Data do Pagamento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTimeOffset? DataPagamento { get; set; } = DateTime.Now;


        public decimal? Juros { get; set; } = 0;


        public decimal? Multa { get; set; } = 0;


        public int Parcela { get; set; } = 1;

        [Display(Name = "Nº Parcelas")]
        public int QtdeParcelas { get; set; } = 1;


        [DataType(DataType.Currency)]
        public decimal Valor { get; set; } = 0;


        
        [Display(Name = "Valor original")]
        [DataType(DataType.Currency)]
        public decimal ValorOriginal { get; set; } = 0;

        [Display(Name = "Valor Pago")]
        [DataType(DataType.Currency)]
        public decimal ValorPago { get; set; } = 0;

        [Display(Name = "Valor Desconto")]
        [DataType(DataType.Currency)]
        public decimal ValorDesconto { get; set; } = 0;



        [Display(Name = "Valor atualizado")]
        [DataType(DataType.Currency)]
        public decimal ValorAtualizado { get; set; } = 0;



        [Display(Name = "Dias em atraso")]
        public int? DiasEmAtrado { get; set; } = 0;
    }
}

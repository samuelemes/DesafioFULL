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
        
        public DocumentoViewModel? DocumentoOrigem { get; set; }

        public PessoaViewModel Pessoa { get; set; }


        [Required]
        [Display(Name = "Data de Vencimento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Data do Pagamento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTimeOffset? DataPagamento { get; set; }


        public decimal? Juros { get; set; }


        public decimal? Multa { get; set; }


        public int Parcela { get; set; }

        [Display(Name = "Nº Parcelas")]
        public int QtdeParcelas { get; set; }


        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }


        
        [Display(Name = "Valor original")]
        [DataType(DataType.Currency)]
        public decimal ValorOriginal { get; set; }

        [Display(Name = "Valor Pago")]
        [DataType(DataType.Currency)]
        public decimal ValorPago { get; set; }

        [Display(Name = "Valor Desconto")]
        [DataType(DataType.Currency)]
        public decimal ValorDesconto { get; set; }



        [Display(Name = "Valor atualizado")]
        [DataType(DataType.Currency)]
        public decimal ValorAtualizado { get; set; }



        [Display(Name = "Dias em atraso")]
        public int? DiasEmAtrado { get; set; }
    }
}

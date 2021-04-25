using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Api.ViewModels
{
    public class BaseViewModel
    {
        [Key]

        [DisplayName("Número ")]
        public int Id { get; set; }
    }
}

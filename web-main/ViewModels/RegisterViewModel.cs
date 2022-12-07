using pim_web.Models;
using pim_web.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace pim_web.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public TipoCliente TipoCliente { get; set; }
        [Required]
        public ClienteModel Cliente { get; set; }
        [Required]
        public string ConfirmSenha { get; set; }
    }
}

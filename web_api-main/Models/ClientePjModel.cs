using web_api.Enums;

namespace web_api.Models
{
    public class ClientePjModel: ClienteBaseModel
    {
        public string? RazaoSocial { get; set; }
        public string? ContratoSocial { get; set; }
        public string? Cnpj { get; set; }
        public string? DataCriacao { get; set; }
        public TipoCliente? TipoCliente { get; set; }
        public Status? Status { get; set; }
    }
}

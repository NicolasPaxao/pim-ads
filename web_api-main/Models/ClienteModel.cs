using web_api.Enums;

namespace web_api.Models
{
    public class ClienteModel : ClienteBaseModel
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Cnh { get; set; }
        public string? Rg { get; set; }
        public string? DataNascimento { get; set; }
        public EstadoCivil? EstadoCivil { get; set; }
        public Sexo? Sexo { get; set; }
        public string? RazaoSocial { get; set; }
        public string? ContratoSocial { get; set; }
        public string? Cnpj { get; set; }
        public string? DataCriacao { get; set; } 
        public TipoCliente? TipoCliente { get; set; }
        public Status? Status { get; set; }

    }
}

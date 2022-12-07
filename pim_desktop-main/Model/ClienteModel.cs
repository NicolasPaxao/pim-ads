using pim_desktop.Enums;

namespace pim_desktop.Model
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Telefone { get; set; }
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

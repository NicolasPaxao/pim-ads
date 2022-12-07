using pim_desktop.Enums;

namespace pim_desktop.Model
{
    public class SeguradoraModel
    {
        public int? Id { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public string? ContratoSocial { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public Status? Status { get; set; }
    }
}

namespace pim_desktop.Model
{
    public abstract class ClienteBaseModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Telefone { get; set; }
    }
}

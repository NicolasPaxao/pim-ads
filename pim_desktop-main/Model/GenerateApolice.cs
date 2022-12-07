using pim_desktop.Enums;

namespace pim_desktop.Model
{
    public class GenerateApolice
    {
        public int? Id { get; set; }
        public AutomovelModel? Automovel { get; set; }
        public string? ClienteNome { get; set; }
        public string? PlanoNome { get; set; }
        public decimal? PlanoValor { get; set; }
        public int? TempoVigencia { get; set; }
        public FormaPagamento? FormaPagamento { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}

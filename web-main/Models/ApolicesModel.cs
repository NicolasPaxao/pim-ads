using pim_web.Models.Enums;

namespace pim_web.Models
{
    public class ApolicesModel
    {
        public int? Id { get; set; }
        public int? PlanoId { get; set; }
        public AutomovelModel? Automovel { get; set; }
        public string? ClienteNome { get; set; }
        public string? PlanoNome { get; set; }
        public decimal? PlanoValor { get; set; }
        public int? TempoVigencia { get; set; }
        public FormaPagamento? FormaPagamento { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}

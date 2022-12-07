using web_api.Enums;

namespace web_api.Models
{
    public class ApolicesModel
    {
        public int? Id { get; set; }
        public int? IdCliente{ get; set; }
        public int? IdAutomovel { get; set; }
        public int? IdPlano { get; set; }
        public int? IdFuncionario { get; set; }
        public FormaPagamento? FormaPagamento { get; set; }
        public DateTime? DataCriacaoApolice { get; set; }
        public int? TempoVigencia { get; set; }

    }
}

using pim_desktop.Enums;

namespace pim_desktop.Model
{
    public class ApolicesModel
    {
        public int? Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdPlano { get; set; }
        public int? IdFuncionario { get; set; }
        public int IdAutomovel { get; set; }
        public FormaPagamento? FormaPagamento { get; set; }
        public DateTime? DataCriacaoApolice { get; set; }

    }
}

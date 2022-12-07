using pim_desktop.Enums;

namespace pim_desktop.Model
{
    public class PlanoModel
    {
        public int? Id { get; set; }
        public string? NomePlano { get; set; }
        public int? IdSeguradora { get; set; }
        public decimal? Valor { get; set; }
        public TipoPlano? TipoPlano { get; set; }
        public Status? Status { get; set; }

    }
}

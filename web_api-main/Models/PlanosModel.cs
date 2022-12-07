using web_api.Enums;

namespace web_api.Models
{
    public class PlanosModel
    {
        public int? Id { get; set; }
        public string? NomePlano { get; set; }
        public decimal? Valor { get; set; }
        public int? IdSeguradora { get; set; }
        public TipoPlano? TipoPlano { get; set; }
        public Status? Status { get; set; }
    }
}

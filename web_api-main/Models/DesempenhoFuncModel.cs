namespace web_api.Models
{
    public class DesempenhoFuncModel
    {
        public int? IdApolice { get; set; }
        public int? IdFuncionario { get; set; }
        public decimal? ValorPlano { get; set; }
        public string? FuncionarioNome { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}

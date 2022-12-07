namespace web_api.Models
{
    public class CoberturaModel
    {
        public int? Id { get; set; }
        public int? IdPlano { get; set; }
        public string? Nome { get; set; }
        public string? Descriacao { get; set; }
        public decimal Indenizacao { get; set; }
    }
}

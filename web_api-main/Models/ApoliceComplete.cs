namespace web_api.Models
{
    public class ApoliceComplete
    {
        public GenerateApolice? Apolice { get; set; }
        public List<AssistenciaModel>? Assistencias { get; set; }
        public List<CoberturaModel>? Cobertura { get; set; }
    }
}

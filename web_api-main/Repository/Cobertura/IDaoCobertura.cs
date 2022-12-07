using web_api.Models;

namespace web_api.Repository.Cobertura
{
    public interface IDaoCobertura
    {
        List<CoberturaModel> GetAllCoberturas();

        public string PostCobertura(CoberturaModel cobertura);

        public void PutCobertura(CoberturaModel cobertura);

        public void DeleteCobertura(int id);
    }
}

using web_api.Models;

namespace web_api.Repository.Apolice
{
    public interface IDaoApolice
    {
        List<ApolicesModel> GetAllApolices();

        public string PostApolice(ApolicesModel apolice);

        List<GenerateApolice> GetApolicesByCarId();
    }
}

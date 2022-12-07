using web_api.Models;

namespace web_api.Repository.Planos
{
    public interface IDaoPlano
    {
        List<PlanosModel> GetAllPlanos();

        public string PostPlano(PlanosModel plano);

        public void PutPlano(PlanosModel plano);

        public void DeletePlano(int id);
    }
}

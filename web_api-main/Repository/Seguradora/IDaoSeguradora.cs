using web_api.Models;

namespace web_api.Repository.Seguradora
{
    public interface IDaoSeguradora
    {
        List<SeguradoraModel> GetAllSeguradoras();

        public string PostSeguradora(SeguradoraModel seguradora);

        public void PutSeguradora(SeguradoraModel seguradora);

        public void DeleteSeguradora(int id);

    }
}

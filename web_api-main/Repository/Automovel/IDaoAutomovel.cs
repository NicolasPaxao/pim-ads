using api_teste.Models;
using web_api.Models;

namespace web_api.Repository.Automovel
{
    public interface IDaoAutomovel
    {
        List<AutomovelModel> GetAllAutomoveis();
        string PostAutomovel(AutomovelModel automovel);
        void PutAutomovel(AutomovelModel automovel);
        void DeleteAutomovel(int id);
        void ChangeAutomovelStatus(AutomovelModel automovel);

    }
}

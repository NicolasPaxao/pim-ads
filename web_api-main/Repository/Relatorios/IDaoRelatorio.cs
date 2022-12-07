using web_api.Models;

namespace web_api.Repository.Relatorios
{
    public interface IDaoRelatorio
    {
        List<DesempenhoFuncModel> GetDesempenhoFuncList(string data, int id);
        List<DesempenhoEmpModel> GetDesempenhoEmpList(string data);
    }
}

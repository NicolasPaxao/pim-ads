using api_teste.Models;

namespace web_api.Repository.Funcionarios
{
    public interface IDaoFuncionario
    {
        List<FuncionarioModel> GetAllFuncionarios();
        string PostFuncionario(FuncionarioModel funcionario);
        string PutFuncionario(FuncionarioModel funcionario);
        void ChangeFuncionarioStatus(FuncionarioModel funcionario);
        string DeleteFuncionario(int id);
    }
}

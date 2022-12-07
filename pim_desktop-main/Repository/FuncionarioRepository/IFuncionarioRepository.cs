using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.FuncionarioRepository
{
    public interface IFuncionarioRepository
    {
        Task<List<FuncionarioModel>> GetAllFuncionarios();
        Task<FuncionarioModel> GetFuncionarioById(int id);
        void PostFuncionario(FuncionarioModel funcionario);
        void DeletarFuncionario(int id);
        void AlterarDadosFuncionario(FuncionarioModel funcionario);

    }
}

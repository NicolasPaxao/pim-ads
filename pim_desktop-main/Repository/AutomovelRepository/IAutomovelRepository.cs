using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.AutomovelRepository
{
    public interface IAutomovelRepository
    {
        Task<List<AutomovelModel>> GetAllAutomoveis();
        Task<AutomovelModel> GetAutomovelById(int id);
        void PostAutomovel(AutomovelModel automovel);
        void DeletarAutomovel(int id);
        void AlterarDadosAutomovel(AutomovelModel automovel);
        void ChangeStatusAutomovel(AutomovelModel automovel);
    }
}

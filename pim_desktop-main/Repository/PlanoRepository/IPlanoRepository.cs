using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.PlanoRepository
{
    public interface IPlanoRepository
    {
        Task<List<PlanoModel>> GetAllPlanos();
        Task<PlanoModel> GetPlanoById(int id);
        void PostPlano(PlanoModel plano);
        void DeletarPlano(int id);
        void AlterarDadosPlano(PlanoModel plano);
    }
}

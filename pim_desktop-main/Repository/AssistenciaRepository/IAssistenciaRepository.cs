using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.AssistenciaRepository
{
    public interface IAssistenciaRepository
    {
        Task<List<AssistenciaModel>> GetAllAssistencias();
        Task<AssistenciaModel> GetAssistenciaById(int id);
        void PostAssistencia(AssistenciaModel assistencia);
        void DeletarAssistencia(int id);
        void AlterarDadosAssistencia(AssistenciaModel assistencia);
    }
}

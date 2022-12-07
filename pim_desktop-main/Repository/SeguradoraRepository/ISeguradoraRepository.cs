using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.SeguradoraRepository
{
    public interface ISeguradoraRepository
    {
        Task<List<SeguradoraModel>> GetAllSeguradoras();
        Task<SeguradoraModel> GetSeguradoraById(int id);
        void PostSeguradora(SeguradoraModel seguradora);
        void DeletarSeguradora(int id);
        void AlterarDadosSeguradora(SeguradoraModel seguradora);
    }
}

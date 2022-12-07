using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.CoberturaRepository
{
    public interface ICoberturaRepository
    {
        Task<List<CoberturaModel>> GetAllCoberturas();
        Task<CoberturaModel> GetCoberturaById(int id);
        void PostCobertura(CoberturaModel cobertura);
        void DeletarCobertura(int id);
        void AlterarDadosCobertura(CoberturaModel cobertura);
    }
}

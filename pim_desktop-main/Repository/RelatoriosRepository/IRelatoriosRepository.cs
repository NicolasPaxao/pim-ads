using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.RelatoriosRepository
{
    public interface IRelatoriosRepository
    {
        Task<List<DesempenhoEmpModel>> GetDesempenhoEmp(string data);
        Task<List<DesempenhoFuncModel>> GetDesempenhoFunc(string data, int id);
    }
}

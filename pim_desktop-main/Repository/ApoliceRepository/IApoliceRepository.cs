using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.ApoliceRepository
{
    public interface IApoliceRepository
    {
        Task<List<ApolicesModel>> GetAllApolices();
        Task<GenerateApolice> GetApoliceByCarId(int id);
        void PostApolice(ApolicesModel apolice);
    }
}

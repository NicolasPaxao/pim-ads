using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.ClienteRepository
{
    public interface IClienteRepository
    {
        Task<List<ClienteModel>> GetAllClientes();
        Task<List<ClientePfModel>> GetAllClientesPf();
        Task<List<ClientePjModel>> GetAllClientesPj();
        Task<ClienteModel> GetClienteById(int id);
        void PostClientePj(ClienteModel cliente);
        void PostClientePf(ClienteModel cliente);
        void DeletarCliente(int id);
        void AlterarDadosCliente(ClienteModel cliente);
    }
}

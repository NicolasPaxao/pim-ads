using pim_web.Models;
using pim_web.Models.Enums;

namespace pim_web.Repository
{
    public interface IRetornoClienteRepository
    {
        Task<RetornaClienteModel> AuthUser(string email, string senha);
        Task<bool> RegisterUser(ClienteModel cliente);
        Task<List<ClienteModel>> GetAllClientes();
    }
}

using web_api.Models;

namespace web_api.Repository.Cliente
{
    public interface IDaoCliente
    {
        List<ClienteModel> GetAllClients();
        List<ClientePjModel> GetAllClientsPj();
        List<ClientePfModel> GetAllClientsPf();
        string PostClientPf(ClienteModel clientePf);
        string PostClientPj(ClienteModel clientePj);
        void PutClient(ClienteModel cliente);
        string PutLoginClientPf(ClienteModel clientePf);
        string PutLoginClientPj(ClienteModel clientePj);
        void ChangeStatusClientById(ClienteModel cliente);
        string DeleteClient(int id);


    }
}

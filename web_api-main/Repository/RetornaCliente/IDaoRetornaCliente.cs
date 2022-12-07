using web_api.Models;

namespace web_api.Repository.RetornaCliente
{
    public interface IDaoRetornaCliente
    {
        ReturnClienteModel ReturnClientProperties(string email, string senha);
    }
}

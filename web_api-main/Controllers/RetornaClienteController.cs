using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using web_api.Models;
using web_api.Repository.Cliente;
using web_api.Repository.RetornaCliente;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class RetornaClienteController : ControllerBase
    {
        private readonly IDaoRetornaCliente _rtnCliente;
        public RetornaClienteController(IDaoRetornaCliente rtnCliente) => _rtnCliente = rtnCliente;

        /// <summary>
        /// Retorna o cliente
        /// </summary>
        [HttpGet("{email},{senha}")]
        public ActionResult<ReturnClienteModel> ReturnClientProperties(string email, string senha)
        {
            var cliente = _rtnCliente.ReturnClientProperties(email, senha);

            if (cliente.Cliente.Id == 0)
            {
                return NotFound();
            }
            return cliente;
        }

    }
}

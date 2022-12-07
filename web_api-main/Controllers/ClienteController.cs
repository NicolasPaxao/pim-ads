using api_teste.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using web_api.Models;
using web_api.Repository.Cliente;

namespace web_api.Controllers
{
    [Route("api/cliente/")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IDaoCliente _cliente;
        public ClienteController(IDaoCliente cliente) => _cliente = cliente;

        /// <summary>
        /// Retorna uma lista de clientes
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<ClienteModel>> GetClients()
        {
            return  _cliente.GetAllClients();
        }

        /// <summary>
        /// Retorna uma lista de clientes PF
        /// </summary>
        [HttpGet("Pf")]
        public ActionResult<IEnumerable<ClientePfModel>> GetPfClients()
        {
            return _cliente.GetAllClientsPf();
        }

        /// <summary>
        /// Retorna uma lista de clientes PF
        /// </summary>
        [HttpGet("Pj")]
        public ActionResult<IEnumerable<ClientePjModel>> GetPjClients()
        {
            return _cliente.GetAllClientsPj();
        }

        /// <summary>
        /// Retorna um cliente pelo Id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<ClienteModel> GetClientById(int id)
        {

            var cliente = _cliente.GetAllClients().Find(e => e.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        /// <summary>
        /// Cria um cliente Pf
        /// </summary>
        [HttpPost("Pf")]
        public ActionResult<string> PostClientPf([FromBody] ClienteModel clientePf)
        {

            var result = _cliente.PostClientPf(clientePf);

            if (result != "Ok")
            {
                return NotFound();
            }
            return result;

        }

        /// <summary>
        /// Cria um cliente Pj
        /// </summary>
        [HttpPost("Pj")]
        public ActionResult<string> PostClientPj([FromBody] ClienteModel clientePj)
        {

            var result = _cliente.PostClientPj(clientePj);

            if (result != "Ok")
            {
                return NotFound();
            }
            return result;
        }

        /// <summary>
        /// Altera os dados possíveis do cliente
        /// </summary>
        [HttpPut("{id}")]
        public void PutClient([FromBody] ClienteModel cliente)
        {
            _cliente.PutClient(cliente);
        }

        /// <summary>
        /// Adiciona o login ao cliente Pf
        /// </summary>
        [HttpPut("PfLogin/{cpf}")]
        public ActionResult<string> PutLoginClientPf([FromBody] ClienteModel clientePf)
        {
            var result = _cliente.PutLoginClientPf(clientePf);
            if (result != "Ok")
            {
                return NotFound();
            }
            return result;
        }

        /// <summary>
        /// Adiciona o login ao cliente Pj
        /// </summary>
        [HttpPut("PjLogin/{cnpj}")]
        public ActionResult<string> PutLoginClientPj([FromBody] ClienteModel clientePj)
        {
            var result = _cliente.PutLoginClientPj(clientePj);
            if (result != "Ok")
            {
                return NotFound();
            }
            return result;
        }

        /// <summary>
        /// Muda o status do cliente
        /// </summary>
        [HttpPut("PfChangeStatus/{id}")]
        public void ChangeStatusClientById([FromBody] ClienteModel cliente)
        {
            _cliente.ChangeStatusClientById(cliente);
        }

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        [HttpDelete("Pf/{id}")]
        public ActionResult<string> DeleteClient(int id)
        {
           var a = _cliente.DeleteClient(id);
            if (a != "Ok")
            {
                return NotFound();
            }
            else
                return a;
        }
    }
}

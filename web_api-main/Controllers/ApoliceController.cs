using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using web_api.Models;
using web_api.Repository.Apolice;
using web_api.Repository.Assistencia;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/apolice")]
    [ApiController]
    public class ApoliceController : ControllerBase
    {
        private readonly IDaoApolice _apolice;

        public ApoliceController(IDaoApolice apolice) => _apolice = apolice;
        /// <summary>
        /// Retorna uma lista de apolices.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<ApolicesModel>> GetAllApolices()
        {
            return _apolice.GetAllApolices();
        }

        /// <summary>
        /// Retorna uma apolice pelo Id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<GenerateApolice> GetApoliceByCarId(int id)
        {
            var apolice = _apolice.GetApolicesByCarId().Find(e => e.Automovel.Id == id);
            if (apolice == null)
            {
                return NotFound();
            }
            return apolice;
        }

        /// <summary>
        /// Cria uma apolice nova
        /// </summary>
        [HttpPost]
        public ActionResult<string> PostApolice([FromBody] ApolicesModel apolice)
        {
            var result = _apolice.PostApolice(apolice);
            if(result != "Ok")
            {
                return NotFound();
            }
            return result;
        }
    }
}

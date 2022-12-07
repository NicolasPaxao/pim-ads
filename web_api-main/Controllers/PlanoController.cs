using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Repository.Planos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_teste.Controllers
{
    [Route("api/plano")]
    [ApiController]
    public class PlanoController : ControllerBase
    {
        private readonly IDaoPlano _plano;

        public PlanoController(IDaoPlano plano) => _plano = plano;


        /// <summary>
        /// Retorna uma lista de planos.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<PlanosModel>> GetAllPlanos()
        {
            return _plano.GetAllPlanos();
        }

        /// <summary>
        /// Retorna um plano pelo Id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<PlanosModel> GetPlanoById(int id)
        {
            var plano = _plano.GetAllPlanos().Find(e => e.Id == id);
            if (plano == null)
            {
                return NotFound();
            }
            return plano;
        }

        /// <summary>
        /// Cria um plano novo
        /// </summary>
        [HttpPost]
        public ActionResult<string> PostPlano([FromBody] PlanosModel plano)
        {

           var a =  _plano.PostPlano(plano);
            if (a != "Ok")
            {
                return NotFound();
            }
            else
                return a;
        }

        /// <summary>
        /// Altera os dados do plano pelo Id
        /// </summary>
        [HttpPut("{id}")]
        public void PutPlano([FromBody] PlanosModel plano)
        {
            _plano.PutPlano(plano);
        }

        /// <summary>
        /// Deleta o registro de um plano pelo seu Id
        /// </summary>
        [HttpDelete("{id}")]
        public void DeletePlano(int id)
        {
            _plano.DeletePlano(id);
        }
    }
}

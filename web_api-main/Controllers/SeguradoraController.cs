using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Repository.Seguradora;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/seguradora")]
    [ApiController]
    public class SeguradoraController : ControllerBase
    {
        private readonly IDaoSeguradora _seguradora;

        public SeguradoraController(IDaoSeguradora seguradora) => _seguradora = seguradora;


        /// <summary>
        /// Retorna uma lista de seguradoras.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<SeguradoraModel>> GetAllSeguradoras()
        {
            return _seguradora.GetAllSeguradoras();
        }

        /// <summary>
        /// Retorna uma seguradora pelo Id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<SeguradoraModel> GetSeguradoraById(int id)
        {
            var seguradora = _seguradora.GetAllSeguradoras().Find(e => e.Id == id);
            if (seguradora == null)
            {
                return NotFound();
            }
            return seguradora;
        }

        /// <summary>
        /// Cria uma seguradora nova
        /// </summary>
        [HttpPost]
        public ActionResult<string> PostSeguradora([FromBody] SeguradoraModel seguradora)
        {

            var a = _seguradora.PostSeguradora(seguradora);
            if (a != "Ok")
            {
                return NotFound();
            }
            else
                return a;
        }

        /// <summary>
        /// Altera os dados da seguradora pelo Id
        /// </summary>
        [HttpPut("{id}")]
        public void PutSeguradora([FromBody] SeguradoraModel seguradora)
        {
            _seguradora.PutSeguradora(seguradora);
        }

        /// <summary>
        /// Deleta o registro de uma seguradora pelo seu Id
        /// </summary>
        [HttpDelete("{id}")]
        public void DeleteSeguradora(int id)
        {
            _seguradora.DeleteSeguradora(id);
        }
    }
}

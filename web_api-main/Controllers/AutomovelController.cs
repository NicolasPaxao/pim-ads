using api_teste.Models;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Repository.Automovel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/automovel")]
    [ApiController]
    public class AutomovelController : ControllerBase
    {
        private readonly IDaoAutomovel _automovel;

        public AutomovelController(IDaoAutomovel automovel) => _automovel = automovel;


        /// <summary>
        /// Retorna uma lista de automoveis.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<AutomovelModel>> GetAllAutomoveis()
        {
            return _automovel.GetAllAutomoveis();
        }

        /// <summary>
        /// Retorna um automovel pelo Id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<AutomovelModel> GetAutomovelById(int id)
        {
            var automovel = _automovel.GetAllAutomoveis().Find(e => e.Id == id);
            if (automovel == null)
            {
                return NotFound();
            }
            return automovel;
        }

        /// <summary>
        /// Cria uma automovel novo
        /// </summary>
        [HttpPost]
        public ActionResult<string> PostAutomovel([FromBody] AutomovelModel automovel)
        {

            var a = _automovel.PostAutomovel(automovel);
            if (a != "Ok")
            {
                return NotFound();
            }
            else
                return a;
        }

        /// <summary>
        /// Altera os dados do automovel pelo Id
        /// </summary>
        [HttpPut("{id}")]
        public void PutAutomovel([FromBody] AutomovelModel automovel)
        {
            _automovel.PutAutomovel(automovel);
        }

        /// <summary>
        /// Altera o status do automovel pelo Id
        /// </summary>
        [HttpPut("status/{id}")]
        public void ChangeStatus([FromBody] AutomovelModel automovel)
        {
            _automovel.ChangeAutomovelStatus(automovel);
        }

        /// <summary>
        /// Deleta o registro de um automovel pelo seu Id
        /// </summary>
        [HttpDelete("{id}")]
        public void DeleteAutomovel(int id)
        {
            _automovel.DeleteAutomovel(id);
        }
    }
}

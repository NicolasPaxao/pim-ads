using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Repository.Assistencia;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/assistencia")]
    [ApiController]
    public class AssistenciaController : ControllerBase
    {
        private readonly IDaoAssistencia _assistencia;

        public AssistenciaController(IDaoAssistencia assistencia) => _assistencia = assistencia;


        /// <summary>
        /// Retorna uma lista de assistencias.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<AssistenciaModel>> GetAllAssistencias()
        {
            return _assistencia.GetAllAssistencias();
        }

        [HttpGet("planos/{planId}")]
        public ActionResult<IEnumerable<AssistenciaModel>> GetAllAssistenciasByPlanId(int planId)
        {
            var assistencias = _assistencia.GetAllAssistencias().FindAll((e)=>e.IdPlano == planId);
            if (assistencias.Count == 0)
            {
                return NotFound();
            }
            else
                return assistencias;
        }

        /// <summary>
        /// Retorna uma assistencia pelo Id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<AssistenciaModel> GetAssistenciaById(int id)
        {
            var assistencia = _assistencia.GetAllAssistencias().Find(e => e.Id == id);
            if (assistencia == null)
            {
                return NotFound();
            }
            else
                return assistencia;
        }

        /// <summary>
        /// Cria uma assistencia nova
        /// </summary>
        [HttpPost]
        public ActionResult<string> PostAssistencia([FromBody] AssistenciaModel assistencia)
        {

            var a = _assistencia.PostAssistencia(assistencia);
            if (a != "Ok")
            {
                return NotFound();
            }
            else
                return a;
        }

        /// <summary>
        /// Altera os dados da assistencia pelo Id
        /// </summary>
        [HttpPut("{id}")]
        public void PutAssistencia([FromBody] AssistenciaModel assistencia)
        {
            _assistencia.PutAssistencia(assistencia);
        }

        /// <summary>
        /// Deleta o registro de uma assistencia pelo seu Id
        /// </summary>
        [HttpDelete("{id}")]
        public void DeleteAssistencia(int id)
        {
            _assistencia.DeleteAssistencia(id);
        }
    }
}

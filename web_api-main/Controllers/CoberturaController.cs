using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Repository.Cobertura;
using web_api.Repository.Seguradora;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/cobertura")]
    [ApiController]
    public class CoberturaController : ControllerBase
    {
        private readonly IDaoCobertura _cobertura;

        public CoberturaController(IDaoCobertura cobertura) => _cobertura = cobertura;


        /// <summary>
        /// Retorna uma lista de coberturas.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<CoberturaModel>> GetAllCoberturas()
        {
            return _cobertura.GetAllCoberturas();
        }

        [HttpGet("planos/{planId}")]
        public ActionResult<IEnumerable<CoberturaModel>> GetAllCoberturasByPlanId(int planId)
        {
            var coberturas = _cobertura.GetAllCoberturas().FindAll((e)=> e.IdPlano == planId);
            if (coberturas.Count == 0)
            {
                return NotFound();
            }
            else
            return coberturas;
        }

        /// <summary>
        /// Retorna uma cobertura pelo Id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<CoberturaModel> GetCoberturaById(int id)
        {
            var cobertura = _cobertura.GetAllCoberturas().Find(e => e.Id == id);
            if (cobertura == null)
            {
                return NotFound();
            }
            return cobertura;
        }

        /// <summary>
        /// Cria uma cobertura nova
        /// </summary>
        [HttpPost]
        public ActionResult<string> PostCobertura([FromBody] CoberturaModel cobertura)
        {

            var a = _cobertura.PostCobertura(cobertura);
            if (a != "Ok")
            {
                return NotFound();
            }
            else
                return a;
        }

        /// <summary>
        /// Altera os dados da cobertura pelo Id
        /// </summary>
        [HttpPut("{id}")]
        public void PutCobertura([FromBody] CoberturaModel cobertura)
        {
            _cobertura.PutCobertura(cobertura);
        }

        /// <summary>
        /// Deleta o registro de uma cobertura pelo seu Id
        /// </summary>
        [HttpDelete("{id}")]
        public void DeleteCobertura(int id)
        {
            _cobertura.DeleteCobertura(id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Repository.Apolice;
using web_api.Repository.Relatorios;

namespace web_api.Controllers
{
    [Route("api/relatorios")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IDaoRelatorio _relatorio;

        public RelatoriosController(IDaoRelatorio relatorio) => _relatorio = relatorio;

        /// <summary>
        /// Retorna uma lista de desempenhos de funcionario.
        /// </summary>
        [HttpGet("func/{data},{id}")]
        public ActionResult<IEnumerable<DesempenhoFuncModel>> GetDesempenhoFunc(string data, int id)
        {
            var desemp = _relatorio.GetDesempenhoFuncList(data, id);
            if(desemp.Count != 0)
                return desemp;
            else
                return NotFound();
        }

        /// <summary>
        /// Retorna uma lista de desempenhos de empresa.
        /// </summary>
        [HttpGet("emp/{data}")]
        public ActionResult<IEnumerable<DesempenhoEmpModel>> GetDesempenhoEmp(string data)
        {
            var desemp = _relatorio.GetDesempenhoEmpList(data);
            if (desemp.Count != 0)
                return desemp;
            else
                return NotFound();
        }
    }
}

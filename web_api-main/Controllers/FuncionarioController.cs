using api_teste.Models;
using Microsoft.AspNetCore.Mvc;
using web_api.Repository.Funcionarios;

namespace api_teste.Controllers
{
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IDaoFuncionario _funcionario;

        public FuncionarioController(IDaoFuncionario funcionario) => _funcionario = funcionario;


        /// <summary>
        /// Retorna uma lista de funcionarios.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<FuncionarioModel>> Get()
        {
            return _funcionario.GetAllFuncionarios();
        }

        /// <summary>
        /// Retorna um funcionario pelo Id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<FuncionarioModel> GetFuncionarioById(int id)
        {
            var func = _funcionario.GetAllFuncionarios().Find(e => e.Id == id);
            if (func == null)
            {
                return NotFound();
            }
            return func;
        }

        /// <summary>
        /// Cria uma funcionario novo
        /// </summary>
        [HttpPost]
        public ActionResult<string> Post([FromBody] FuncionarioModel funcionario)
        {

           var a =  _funcionario.PostFuncionario(funcionario);
            if (a != "Ok")
            {
                return NotFound();
            }
            else
                return a;
        }

        /// <summary>
        /// Altera os dados do funcionario pelo Id
        /// </summary>
        [HttpPut("{id}")]
        public void Put([FromBody] FuncionarioModel funcionario)
        {
            _funcionario.PutFuncionario(funcionario);
        }

        /// <summary>
        /// Muda o status do funcionario baseado no Id
        /// </summary>
        [HttpPut("changeStatus/{id}")]
        public void ChangeFuncionarioStatus([FromBody] FuncionarioModel funcionario)
        {
            _funcionario.ChangeFuncionarioStatus(funcionario);
        }

        /// <summary>
        /// Deleta o registro de um usuário pelo seu Id
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var a = _funcionario.DeleteFuncionario(id);
            if (a != "Ok")
            {
                return NotFound();
            }
            else
                return a;
        }
    }
}

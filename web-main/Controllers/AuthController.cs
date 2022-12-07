using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using pim_web.Models;
using pim_web.Repository;
using pim_web.ViewModels;

namespace pim_web.Controllers
{
    public class AuthController : Controller
    {
        RetornaClienteModel? clienteModel;
        RetornoClienteRepository authRepository = new RetornoClienteRepository();
        [HttpGet]
        public IActionResult LoginView()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginView(LoginViewModel model)
        {
            List<ClienteModel> clist;
            string action = "LoginView";
            string controller = "Auth";
            if (model != null)
            {
                clist = await authRepository.GetAllClientes();
                var c = clist.Find((e) => e.Email == model.Email && e.Senha == model.Senha);
                if (c != null)
                {
                    action = "UserPageView";
                    TempData["Id"] = c.Id;
                    TempData["Email"] = c.Email;
                    TempData["Senha"] = c.Senha;
                    TempData["Cep"] = c.Cep;
                    TempData["Logradouro"] = c.Logradouro;
                    TempData["Telefone"] = c.Telefone;
                    TempData["Nome"] = c.Nome;
                    TempData["Cpf"] = c.Cpf;
                    TempData["Cnh"] = c.Cnh;
                    TempData["Rg"] = c.Rg;
                    TempData["DataNascimento"] = c.DataNascimento;
                    if (c.EstadoCivil == Models.Enums.EstadoCivil.Solteiro)
                        TempData["EstadoCivil"] = "Solteiro";
                    if (c.EstadoCivil == Models.Enums.EstadoCivil.Divorciado)
                        TempData["EstadoCivil"] = "Divorciado";
                    if (c.EstadoCivil == Models.Enums.EstadoCivil.Casado)
                        TempData["EstadoCivil"] = "Casado";
                    if (c.EstadoCivil == Models.Enums.EstadoCivil.Viuvo)
                        TempData["EstadoCivil"] = "Viuvo";
                    if (c.Sexo == Models.Enums.Sexo.Masculino)
                        TempData["Sexo"] = "Masculino";
                    if (c.Sexo == Models.Enums.Sexo.Feminino)
                        TempData["Sexo"] = "Feminino";
                    TempData["RazaoSocial"] = c.RazaoSocial;
                    TempData["Cnpj"] = c.Cnpj;
                    TempData["DataCriacao"] = c.DataCriacao;
                    if (c.TipoCliente == Models.Enums.TipoCliente.Pessoa_Fisica)
                        TempData["TipoCliente"] = "Pessoa Física";
                    if (c.TipoCliente == Models.Enums.TipoCliente.Pessoa_Juridica)
                        TempData["TipoCliente"] = "Pessoa Jurídica";
                    TempData["Status"] = c.Status;
                }
                else
                {
                    action = "LoginView";
                    TempData["responseFail"] = "Usuário não encontrado";
                    return RedirectToAction(action, controller);
                }
            }
            return RedirectToAction(action, controller);

        }

        [HttpGet]
        public IActionResult RegisterView()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterView(RegisterViewModel model)
        {
            string action = "LoginView";
            string controller = "Auth";
            ClienteModel cliente = new ClienteModel();
            if (model.Cliente.Cpf != null)
            {
                cliente.Cpf = model.Cliente.Cpf;
                cliente.Senha = model.Cliente.Senha;
                cliente.TipoCliente = Models.Enums.TipoCliente.Pessoa_Fisica;
            }
            else if (model.Cliente.Cnpj != null)
            {
                cliente.Cnpj = model.Cliente.Cnpj;
                cliente.Senha = model.Cliente.Senha;
                cliente.TipoCliente = Models.Enums.TipoCliente.Pessoa_Juridica;
            }
            if (cliente.Cpf != null || cliente.Cnpj != null && cliente.Senha != null)
            {
                if (cliente.Senha == model.ConfirmSenha)
                {
                    ClienteModel cResult = new ClienteModel();
                    var c = await authRepository.GetAllClientes();
                    if (cliente.TipoCliente == Models.Enums.TipoCliente.Pessoa_Fisica)
                         cResult = c.Find((e) => e.Cpf == cliente.Cpf);
                    else
                        cResult = c.Find((e) => e.Cnpj == cliente.Cnpj);

                    if (cResult.Senha == "")
                    {
                        var result = await authRepository.RegisterUser(cliente);
                        if (result == true)
                        {
                            TempData["resultSucess"] = "Cadastro realizado com sucesso!";
                        }
                        else
                            if (cliente.TipoCliente == Models.Enums.TipoCliente.Pessoa_Fisica)
                        {
                            action = "RegisterView";
                            TempData["resultFailCpf"] = "CPF não encontrado no sistema!";
                        }
                        else
                        {
                            action = "RegisterView";
                            TempData["resultFailCnpj"] = "CNPJ não encontrado no sistema!";
                        }
                    }
                    else
                    {
                        action = "RegisterView";
                            TempData["resultRegistred"] = "Este usuário já possui cadastro";
                    }   
                   
                }
                else
                {
                    action = "RegisterView";
                    TempData["formFail"] = cliente.Senha != model.ConfirmSenha ? "As senhas não coincidem" : "Todos os dados são requeridos!";
                }


            }
            else
            {
                action = "RegisterView";
                TempData["formFail"] = cliente.Senha != model.ConfirmSenha ? "As senhas não coincidem" : "Todos os dados são requeridos!";
            }
            Thread.Sleep(600);

            return RedirectToAction(action, controller);
        }

        [HttpGet]
        public IActionResult UserPageView()
        {
            return View();
        }
    }

}

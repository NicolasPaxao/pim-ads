using pim_desktop.Constants;
using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using pim_desktop.Views.Modals;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Net;
using pim_desktop.Validators;

namespace pim_desktop.Repository.FuncionarioRepository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        public async void AlterarDadosFuncionario(FuncionarioModel funcionario)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(Consts.url + "api/funcionario/" + funcionario.Id, funcionario);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("FUNCIONÁRIO ATUALIZADO COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async void DeletarFuncionario(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Consts.url + "api/funcionario");
                HttpResponseMessage response = await client.DeleteAsync(Consts.url + "api/funcionario/" + id);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("FUNCIONÁRIO DELETADO COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("FUNCIONÁRIO COM APÓLICE ASSOCIADA OU NÃO ENCONTRADO").Show();
                }
            }
        }

        public async Task<FuncionarioModel> GetFuncionarioById(int id)
        {
            using (var client = new HttpClient())
            {
                FuncionarioModel funcionario = new FuncionarioModel();
                HttpResponseMessage response = await client.GetAsync(Consts.url + "api/funcionario/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    funcionario = JsonConvert.DeserializeObject<FuncionarioModel>(fromJson);
                    return funcionario;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    new CreateResponseModal("FUNCIONÁRIO NÃO ENCONTRADO").Show();
                    
                    return funcionario;
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }

        public async Task<List<FuncionarioModel>> GetAllFuncionarios()
        {
            List<FuncionarioModel> funcionarios;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.url + "api/funcionario"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        funcionarios = JsonConvert.DeserializeObject<FuncionarioModel[]>(fromJson).ToList();
                        return funcionarios;
                    }
                    else
                    {
                        new CreateResponseModal("NÃO FOI POSSÍVEL OBTER A LISTA\n" + response.StatusCode).Show();
                        throw new Exception("");
                    }

                }
            }

        }

        public async void PostFuncionario(FuncionarioModel funcionario)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var toJson = JsonConvert.SerializeObject(funcionario);
                    var content = new StringContent(toJson, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Consts.url + "api/funcionario", content);
                    if(result.IsSuccessStatusCode)
                    {
                        new CreateResponseModal("REGISTRO CRIADO COM SUCESSO!").Show();
                    }
                    else
                    {
                        new CreateResponseModal("CPF JÁ CADASTRADO\nOU\nDADOS INVÁLIDOS").Show();
                    }
                    

                }
                catch (Exception e)
                {

                    new CreateResponseModal("UM ERRO ACONTECEU!\n" + e.Message).Show();

                }

            }

        }
    }
}

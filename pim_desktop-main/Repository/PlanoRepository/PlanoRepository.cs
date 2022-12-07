using Newtonsoft.Json;
using pim_desktop.Constants;
using pim_desktop.Model;
using pim_desktop.Views.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.PlanoRepository
{
    public class PlanoRepository : IPlanoRepository
    {
        public async void AlterarDadosPlano(PlanoModel plano)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(Consts.url + "api/plano/" + plano.Id, plano);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("PLANO ATUALIZADO COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async void DeletarPlano(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Consts.url + "api/plano");
                HttpResponseMessage response = await client.DeleteAsync(Consts.url + "api/plano/" + id);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("PLANO DELETADO COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async Task<List<PlanoModel>> GetAllPlanos()
        {
            List<PlanoModel> plano;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.url + "api/plano"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        plano = JsonConvert.DeserializeObject<PlanoModel[]>(fromJson).ToList();
                        return plano;
                    }
                    else
                    {
                        new CreateResponseModal("NÃO FOI POSSÍVEL OBTER A LISTA\n" + response.StatusCode).Show();
                        throw new Exception("");
                    }

                }
            }
        }

        public async Task<PlanoModel> GetPlanoById(int id)
        {
            using (var client = new HttpClient())
            {
                PlanoModel plano = new PlanoModel();
                HttpResponseMessage response = await client.GetAsync(Consts.url + "api/plano/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    plano = JsonConvert.DeserializeObject<PlanoModel>(fromJson);
                    return plano;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    new CreateResponseModal("PLANO NÃO ENCONTRADO").Show();
                    return plano;
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }

        public async void PostPlano(PlanoModel plano)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var toJson = JsonConvert.SerializeObject(plano);
                    var content = new StringContent(toJson, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Consts.url + "api/plano", content);

                    if (result.IsSuccessStatusCode)
                    {
                        new CreateResponseModal("REGISTRO CRIADO COM SUCESSO!").Show();
                    }
                    else
                    {
                        new CreateResponseModal("PLANO JÁ CADASTRADO\nOU\nDADOS INVÁLIDOS").Show();
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

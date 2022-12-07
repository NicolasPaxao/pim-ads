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

namespace pim_desktop.Repository.AutomovelRepository
{
    public class AutomovelRepository : IAutomovelRepository
    {
        public async void AlterarDadosAutomovel(AutomovelModel automovel)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(Consts.url + "api/automovel/" + automovel.Id, automovel);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("AUTOMOVEL ATUALIZADO COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async void ChangeStatusAutomovel(AutomovelModel automovel)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(Consts.url + "api/automovel/status/" + automovel.Id, automovel);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("AUTOMÓVEL ATIVO").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async void DeletarAutomovel(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Consts.url + "api/automovel");
                HttpResponseMessage response = await client.DeleteAsync(Consts.url + "api/automovel/" + id);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("AUTOMOVEL DELETADO COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async Task<List<AutomovelModel>> GetAllAutomoveis()
        {
            List<AutomovelModel> automovel;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.url + "api/automovel"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        automovel = JsonConvert.DeserializeObject<AutomovelModel[]>(fromJson).ToList();
                        return automovel;
                    }
                    else
                    {
                        new CreateResponseModal("NÃO FOI POSSÍVEL OBTER A LISTA\n" + response.StatusCode).Show();
                        throw new Exception("");
                    }

                }
            }
        }

        public async Task<AutomovelModel> GetAutomovelById(int id)
        {
            using (var client = new HttpClient())
            {
                AutomovelModel automovel = new AutomovelModel();
                HttpResponseMessage response = await client.GetAsync(Consts.url + "api/automovel/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    automovel = JsonConvert.DeserializeObject<AutomovelModel>(fromJson);
                    return automovel;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    new CreateResponseModal("AUTOMOVEL NÃO ENCONTRADO").Show();
                    return automovel;
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }

        public async void PostAutomovel(AutomovelModel automovel)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var toJson = JsonConvert.SerializeObject(automovel);
                    var content = new StringContent(toJson, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Consts.url + "api/automovel", content);

                    if (result.IsSuccessStatusCode)
                    {
                        new CreateResponseModal("REGISTRO CRIADO COM SUCESSO!").Show();
                    }
                    else
                    {
                        new CreateResponseModal("EMPRESA JÁ CADASTRADA\nOU\nDADOS INVÁLIDOS").Show();
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

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

namespace pim_desktop.Repository.CoberturaRepository
{
    public class CoberturaRepository : ICoberturaRepository
    {
        public async void AlterarDadosCobertura(CoberturaModel cobertura)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(Consts.url + "api/cobertura/" + cobertura.Id, cobertura);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("COBERTURA ATUALIZADA COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async void DeletarCobertura(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Consts.url + "api/cobertura");
                HttpResponseMessage response = await client.DeleteAsync(Consts.url + "api/cobertura/" + id);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("COBERTURA DELETADA COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async Task<List<CoberturaModel>> GetAllCoberturas()
        {
            List<CoberturaModel> cobertura;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.url + "api/cobertura"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        cobertura = JsonConvert.DeserializeObject<CoberturaModel[]>(fromJson).ToList();
                        return cobertura;
                    }
                    else
                    {
                        new CreateResponseModal("NÃO FOI POSSÍVEL OBTER A LISTA\n" + response.StatusCode).Show();
                        throw new Exception("");
                    }

                }
            }
        }

        public async Task<CoberturaModel> GetCoberturaById(int id)
        {
            using (var client = new HttpClient())
            {
                CoberturaModel cobertura = new CoberturaModel();
                HttpResponseMessage response = await client.GetAsync(Consts.url + "api/cobertura/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    cobertura = JsonConvert.DeserializeObject<CoberturaModel>(fromJson);
                    return cobertura;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    new CreateResponseModal("COBERTURA NÃO ENCONTRADA").Show();
                    return cobertura;
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }

        public async void PostCobertura(CoberturaModel cobertura)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var toJson = JsonConvert.SerializeObject(cobertura);
                    var content = new StringContent(toJson, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Consts.url + "api/cobertura", content);

                    if (result.IsSuccessStatusCode)
                    {
                        new CreateResponseModal("REGISTRO CRIADO COM SUCESSO!").Show();
                    }
                    else
                    {
                        new CreateResponseModal("COBERTURA JÁ CADASTRADA\nOU\nDADOS INVÁLIDOS").Show();
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

using Newtonsoft.Json;
using pim_desktop.Constants;
using pim_desktop.Model;
using pim_desktop.Views.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.SeguradoraRepository
{
    public class SeguradoraRepository : ISeguradoraRepository
    {
        public async void AlterarDadosSeguradora(SeguradoraModel seguradora)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(Consts.url + "api/seguradora/" + seguradora.Id, seguradora);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("SEGURADORA ATUALIZADA COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async void DeletarSeguradora(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Consts.url + "api/seguradora");
                HttpResponseMessage response = await client.DeleteAsync(Consts.url + "api/seguradora/" + id);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("SEGURADORA DELETADA COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async Task<List<SeguradoraModel>> GetAllSeguradoras()
        {
            List<SeguradoraModel> seguradora;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.url + "api/seguradora"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        seguradora = JsonConvert.DeserializeObject<SeguradoraModel[]>(fromJson).ToList();
                        return seguradora;
                    }
                    else
                    {
                        new CreateResponseModal("NÃO FOI POSSÍVEL OBTER A LISTA\n" + response.StatusCode).Show();
                        throw new Exception("");
                    }

                }
            }
        }

        public async Task<SeguradoraModel> GetSeguradoraById(int id)
        {
            using (var client = new HttpClient())
            {
                SeguradoraModel seguradora = new SeguradoraModel();
                HttpResponseMessage response = await client.GetAsync(Consts.url + "api/seguradora/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    seguradora = JsonConvert.DeserializeObject<SeguradoraModel>(fromJson);
                    return seguradora;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    new CreateResponseModal("SEGURADORA NÃO ENCONTRADA").Show();
                    return seguradora;
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }

        public async void PostSeguradora(SeguradoraModel seguradora)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var toJson = JsonConvert.SerializeObject(seguradora);
                    var content = new StringContent(toJson, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Consts.url + "api/seguradora", content);

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

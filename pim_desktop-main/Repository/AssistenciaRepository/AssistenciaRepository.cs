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

namespace pim_desktop.Repository.AssistenciaRepository
{
    public class AssistenciaRepository : IAssistenciaRepository
    {
        public async void AlterarDadosAssistencia(AssistenciaModel assistencia)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(Consts.url + "api/assistencia/" + assistencia.Id, assistencia);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("ASSISTÊNCIA ATUALIZADA COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async void DeletarAssistencia(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Consts.url + "api/assistencia");
                HttpResponseMessage response = await client.DeleteAsync(Consts.url + "api/assistencia/" + id);
                if (response.IsSuccessStatusCode)
                {
                    new CreateResponseModal("ASSISTÊNCIA DELETADA COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async Task<List<AssistenciaModel>> GetAllAssistencias()
        {
            List<AssistenciaModel> assistencias;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.url + "api/assistencia"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        assistencias = JsonConvert.DeserializeObject<AssistenciaModel[]>(fromJson).ToList();
                        return assistencias;
                    }
                    else
                    {
                        new CreateResponseModal("NÃO FOI POSSÍVEL OBTER A LISTA\n" + response.StatusCode).Show();
                        throw new Exception("");
                    }

                }
            }
        }

        public async Task<AssistenciaModel> GetAssistenciaById(int id)
        {
            using (var client = new HttpClient())
            {
                AssistenciaModel assistencia = new AssistenciaModel();
                HttpResponseMessage response = await client.GetAsync(Consts.url + "api/assistencia/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    assistencia = JsonConvert.DeserializeObject<AssistenciaModel>(fromJson);
                    return assistencia;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    new CreateResponseModal("ASSISTÊNCIA NÃO ENCONTRADA").Show();
                    return assistencia;
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }

        public async void PostAssistencia(AssistenciaModel assistencia)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var toJson = JsonConvert.SerializeObject(assistencia);
                    var content = new StringContent(toJson, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Consts.url + "api/assistencia", content);

                    if (result.IsSuccessStatusCode)
                    {
                        new CreateResponseModal("REGISTRO CRIADO COM SUCESSO!").Show();
                    }
                    else
                    {
                        new CreateResponseModal("ASSISTÊNCIA JÁ CADASTRADA\nOU\nDADOS INVÁLIDOS").Show();
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

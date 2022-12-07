using Microsoft.Reporting.Map.WebForms.BingMaps;
using Newtonsoft.Json;
using pim_desktop.Constants;
using pim_desktop.Model;
using pim_desktop.Views.Modals;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.ApoliceRepository
{
    public class ApoliceRepository : IApoliceRepository
    {

        public async Task<List<ApolicesModel>> GetAllApolices()
        {
            List<ApolicesModel> apolices;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.url + "api/apolice"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        apolices = JsonConvert.DeserializeObject<ApolicesModel[]>(fromJson).ToList();
                        return apolices;
                    }
                    else
                    {
                        new CreateResponseModal("NÃO FOI POSSÍVEL OBTER A LISTA\n" + response.StatusCode).Show();
                        throw new Exception("");
                    }

                }
            }
        }

        public async Task<GenerateApolice> GetApoliceByCarId(int id)
        {
            using (var client = new HttpClient())
            {
                GenerateApolice apolice = new GenerateApolice();
                HttpResponseMessage response = await client.GetAsync(Consts.url + "api/apolice/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    apolice = JsonConvert.DeserializeObject<GenerateApolice>(fromJson);
                    return apolice;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    new CreateResponseModal("AUTOMOVEL NÃO ENCONTRADO\nOU SEM APOLICE").Show();
                    return apolice;
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }

        

        public async void PostApolice(ApolicesModel apolice)
        {
            using (var client = new HttpClient())
            {
                
                try
                {
                    var toJson = JsonConvert.SerializeObject(apolice);
                    var content = new StringContent(toJson, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Consts.url + "api/apolice", content);
                    if(result.StatusCode != HttpStatusCode.NotFound)
                     new CreateResponseModal("REGISTRO CRIADO COM SUCESSO!").Show();
                    else
                        new CreateResponseModal("ESTE AUTOMÓVEL JÁ\nPOSSUI APÓLICE").Show();

                }
                catch (Exception)
                {
                    new CreateResponseModal("ESTE AUTOMÓVEL JÁ\nPOSSUI APÓLICE").Show();
                }

            }
        }
    }
}

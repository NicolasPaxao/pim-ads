using Newtonsoft.Json;
using pim_desktop.Constants;
using pim_desktop.Model;
using pim_desktop.Views.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Repository.RelatoriosRepository
{
    public class RelatoriosRepository : IRelatoriosRepository
    {
        public async Task<List<DesempenhoEmpModel>> GetDesempenhoEmp(string data)
        {
            using (var client = new HttpClient())
            {
                List<DesempenhoEmpModel> desemps = new List<DesempenhoEmpModel>();
                HttpResponseMessage response = await client.GetAsync(Consts.url + "api/relatorios/emp/" + data);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    desemps = JsonConvert.DeserializeObject<DesempenhoEmpModel[]>(fromJson).ToList();
                    return desemps;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    new CreateResponseModal("MÊS NÃO ENCONTRADO\nOU SEM REGISTROS").Show();
                    return desemps;
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }

        public async Task<List<DesempenhoFuncModel>> GetDesempenhoFunc(string data, int id)
        {
            using (var client = new HttpClient())
            {
                List<DesempenhoFuncModel> desemps = new List<DesempenhoFuncModel>();
                HttpResponseMessage response = await client.GetAsync(Consts.url + "api/relatorios/func/" + data + "," + id);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    desemps = JsonConvert.DeserializeObject<DesempenhoFuncModel[]>(fromJson).ToList();
                    return desemps;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    new CreateResponseModal("FUNCIONÁRIO NÃO ENCONTRADO\nOU\nMÊS SEM REGISTROS").Show();
                    return desemps;
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }
    }
}

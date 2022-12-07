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

namespace pim_desktop.Repository.ClienteRepository
{
    public class ClienteRepository : IClienteRepository
    {
        public async void AlterarDadosCliente(ClienteModel cliente)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(Consts.url + "api/cliente/" + cliente.Id, cliente);
                if (response.IsSuccessStatusCode)
                {
                    if(cliente.TipoCliente == Enums.TipoCliente.Pessoa_Fisica)
                         new CreateResponseModal("CLIENTE PF ATUALIZADO COM SUCESSO!").Show();
                    else
                        new CreateResponseModal("CLIENTE PJ ATUALIZADO COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU!\n" + response.StatusCode).Show();
                }
            }
        }

        public async void DeletarCliente(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(Consts.url + "api/cliente/Pf/" + id);
                if (response.IsSuccessStatusCode)
                {

                    new CreateResponseModal("CLIENTE DELETADO COM SUCESSO!").Show();
                }
                else
                {
                    new CreateResponseModal("CLIENTE COM APÓLICE ASSOCIADA OU NÃO ENCONTRADO").Show();
                }
            }
        }

        public async Task<List<ClienteModel>> GetAllClientes()
        {
            List<ClienteModel> cliente;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.url + "api/cliente"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        cliente = JsonConvert.DeserializeObject<ClienteModel[]>(fromJson).ToList();
                        return cliente;
                    }
                    else
                    {
                        new CreateResponseModal("NÃO FOI POSSÍVEL OBTER A LISTA\n" + response.StatusCode).Show();
                        throw new Exception("");
                    }

                }
            }
        }

        public async Task<List<ClientePfModel>> GetAllClientesPf()
        {
            List<ClientePfModel> cliente;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.url + "api/cliente/Pf"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        cliente = JsonConvert.DeserializeObject<ClientePfModel[]>(fromJson).ToList();
                        return cliente;
                    }
                    else
                    {
                        new CreateResponseModal("NÃO FOI POSSÍVEL OBTER A LISTA: " + response.StatusCode).Show();
                        throw new Exception("");
                    }

                }
            }
        }

        public async Task<List<ClientePjModel>> GetAllClientesPj()
        {
            List<ClientePjModel> cliente;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.url + "api/cliente/Pj"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        cliente = JsonConvert.DeserializeObject<ClientePjModel[]>(fromJson).ToList();
                        return cliente;
                    }
                    else
                    {
                        new CreateResponseModal("NÃO FOI POSSÍVEL OBTER A LISTA: " + response.StatusCode).Show();
                        throw new Exception("");
                    }

                }
            }
        }

        public async Task<ClienteModel> GetClienteById(int id)
        {
            using (var client = new HttpClient())
            {
                ClienteModel cliente = new ClienteModel();
                HttpResponseMessage response = await client.GetAsync(Consts.url + "api/cliente/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    cliente = JsonConvert.DeserializeObject<ClienteModel>(fromJson);
                    return cliente;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    if (cliente.TipoCliente == Enums.TipoCliente.Pessoa_Fisica)
                        new CreateResponseModal("CLIENTE PF NÃO ENCONTRADO").Show();
                    else
                        new CreateResponseModal("CLIENTE PJ NÃO ENCONTRADO").Show();
                    return cliente;
                }
                else
                {
                    new CreateResponseModal("ALGO OCORREU: " + response.StatusCode).Show();
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }


        public async void PostClientePf(ClienteModel cliente)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var toJson = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(toJson, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Consts.url + "api/cliente/Pf", content);

                    if (result.StatusCode != HttpStatusCode.NotFound)
                        new CreateResponseModal("REGISTRO CRIADO COM SUCESSO!").Show();
                    else
                        new CreateResponseModal("ESTE CLIENTE JÁ POSSUI CADASTRO").Show();

                }
                catch (Exception e)
                {

                    new CreateResponseModal("UM ERRO ACONTECEU: " + e.Message).Show();

                }

            }
        }

        public async void PostClientePj(ClienteModel cliente)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var toJson = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(toJson, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Consts.url + "api/cliente/Pj", content);

                    if (result.StatusCode != HttpStatusCode.NotFound)
                        new CreateResponseModal("REGISTRO CRIADO COM SUCESSO!").Show();
                    else
                        new CreateResponseModal("ESTE CLIENTE JÁ POSSUI CADASTRO").Show();

                }
                catch (Exception e)
                {

                    new CreateResponseModal("UM ERRO ACONTECEU: " + e.Message).Show();

                }

            }
        }
    }
}

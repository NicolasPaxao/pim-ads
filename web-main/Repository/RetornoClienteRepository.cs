using System.Net;
using System;
using Newtonsoft.Json;
using pim_web.Models;
using pim_web.Consts;
using pim_web.Models.Enums;

namespace pim_web.Repository
{
    public class RetornoClienteRepository : IRetornoClienteRepository
    {

        public async Task<RetornaClienteModel> AuthUser(string email, string senha)
        {
            using (var client = new HttpClient())
            {
                RetornaClienteModel usuario = new RetornaClienteModel();
                HttpResponseMessage response = await client.GetAsync(Consts.Consts.URL + "api/auth/" + email + "," + senha);
                if (response.IsSuccessStatusCode)
                {
                    var fromJson = await response.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<RetornaClienteModel>(fromJson);
                    return usuario;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return usuario = new RetornaClienteModel();
                }
                else
                {
                    throw new Exception("Erro" + response.StatusCode);
                }
            }
        }

        public async Task<bool> RegisterUser(ClienteModel cliente)
        {
            string URL;
            using (var client = new HttpClient())
            {
                if (cliente.TipoCliente == TipoCliente.Pessoa_Fisica)
                    URL = Consts.Consts.URL + "api/cliente/PfLogin/" + cliente.Cpf;
                else
                    URL = Consts.Consts.URL + "api/cliente/PjLogin/" + cliente.Cnpj;
                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync(URL, cliente);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }if(response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return false;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }
        public async Task<List<ClienteModel>> GetAllClientes()
        {
            List<ClienteModel> cliente;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Consts.Consts.URL + "api/cliente"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fromJson = await response.Content.ReadAsStringAsync();
                        cliente = JsonConvert.DeserializeObject<ClienteModel[]>(fromJson).ToList();
                        return cliente;
                    }
                    else
                    {
                        throw new Exception("");
                    }

                }
            }
        }
    }
}

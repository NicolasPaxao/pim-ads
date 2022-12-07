using api_teste.Models;
using System.Data;
using System.Data.SqlClient;
using web_api.Data;
using web_api.Enums;
using web_api.Models;

namespace web_api.Repository.Cliente
{
    public class DaoCliente : IDaoCliente
    {
        private readonly DataContext _dataContext;

        public DaoCliente(DataContext dataContext) => _dataContext = dataContext;

        public List<ClienteModel> GetAllClients()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetAllClients", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var cliente = new ClienteModel();
                                cliente.Id = (int)reader["cli_id"];
                                cliente.Email = reader["cli_email"].ToString();
                                cliente.Senha = reader["cli_senha"].ToString();
                                cliente.Cep = reader["cli_cep"].ToString();
                                cliente.Logradouro = reader["cli_logradouro"].ToString();
                                cliente.Telefone = reader["cli_telefone"].ToString();
                                cliente.Nome = reader["cli_nome"].ToString();
                                cliente.Cpf = reader["cli_cpf"].ToString();
                                cliente.Cnh = reader["cli_cnh"].ToString();
                                cliente.Rg = reader["cli_rg"].ToString();
                                cliente.DataNascimento = reader["cli_dataNascimento"].ToString();
                                if (reader["cli_estadoCivil"] == null)
                                {
                                    cliente.EstadoCivil = EstadoCivil.Solteiro;
                                }
                                else
                                {
                                    cliente.EstadoCivil = (EstadoCivil)reader["cli_estadoCivil"];
                                }
                                cliente.Sexo = (Sexo)reader["cli_status"];
                                cliente.RazaoSocial = reader["cli_razaoSocial"].ToString();
                                cliente.ContratoSocial = reader["cli_contratoSocial"].ToString();
                                cliente.Cnpj = reader["cli_cnpj"].ToString();
                                cliente.DataCriacao = reader["cli_dataCriacao"].ToString();
                                cliente.TipoCliente = (TipoCliente)reader["cli_tipoCliente"];
                                cliente.Status = (Status)reader["cli_status"];
                                clientes.Add(cliente);
                            }
                        }
                    }
                }
            }
            return clientes;
        }

        public string PostClientPf(ClienteModel clientePf)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PostClientPf", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NOME", clientePf.Nome);
                        cmd.Parameters.AddWithValue("@EMAIL", clientePf.Email);
                        cmd.Parameters.AddWithValue("@CPF", clientePf.Cpf);
                        cmd.Parameters.AddWithValue("@CNH", clientePf.Cnh);
                        cmd.Parameters.AddWithValue("@RG", clientePf.Rg);
                        cmd.Parameters.AddWithValue("@TELEFONE", clientePf.Telefone);
                        cmd.Parameters.AddWithValue("@DATANASCIMENTO", clientePf.DataNascimento);
                        cmd.Parameters.AddWithValue("@CEP", clientePf.Cep);
                        cmd.Parameters.AddWithValue("@LOGRADOURO", clientePf.Logradouro);
                        cmd.Parameters.AddWithValue("@ESTADOCIVIL", clientePf.EstadoCivil);
                        cmd.Parameters.AddWithValue("@SEXO", clientePf.Sexo);
                        int a = cmd.ExecuteNonQuery();
                        if (a == 1)
                        {
                            codeReturn = "Ok";
                            return codeReturn;
                        }
                        else
                        {
                            return "falha";
                        }

                    }
                    catch (SqlException ex)
                    {

                        if (ex.Number == 2601)
                        {
                            codeReturn = "Não foi possível realizar o cadastro";
                            return codeReturn;
                        }
                        else if (ex.Number == 2627)
                        {
                            codeReturn = "Não foi possível realizar o cadastro";
                            return codeReturn;
                        }
                    }
                    return codeReturn;

                }
            }
        }
        public string PostClientPj(ClienteModel clientePj)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PostClientPj", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RAZAOSOCIAL", clientePj.RazaoSocial);
                        cmd.Parameters.AddWithValue("@CONTRATOSOCIAL", clientePj.ContratoSocial);
                        cmd.Parameters.AddWithValue("@EMAIL", clientePj.Email);
                        cmd.Parameters.AddWithValue("@CNPJ", clientePj.Cnpj);
                        cmd.Parameters.AddWithValue("@TELEFONE", clientePj.Telefone);
                        cmd.Parameters.AddWithValue("@DATACRIACAO", clientePj.DataCriacao);
                        cmd.Parameters.AddWithValue("@CEP", clientePj.Cep);
                        cmd.Parameters.AddWithValue("@LOGRADOURO", clientePj.Logradouro);
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            codeReturn = "Ok";
                            return codeReturn;
                        }
                        else
                        {
                            return "falha";
                        }
                    }
                    catch (SqlException ex)
                    {

                        if (ex.Number == 2601)
                        {
                            codeReturn = "Não foi possível realizar o cadastro";
                            return codeReturn;
                        }
                        else if (ex.Number == 2627)
                        {
                            codeReturn = "Não foi possível realizar o cadastro";
                            return codeReturn;
                        }
                    }
                    return codeReturn;

                }
            }
        }
        public void PutClient(ClienteModel cliente)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PutClient", (SqlConnection)con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", cliente.Id);
                    cmd.Parameters.AddWithValue("@TELEFONE ", cliente.Telefone);
                    cmd.Parameters.AddWithValue("@CEP", cliente.Cep);
                    cmd.Parameters.AddWithValue("@LOGRADOURO", cliente.Logradouro);
                    cmd.Parameters.AddWithValue("@ESTADOCIVIL", cliente.EstadoCivil);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public string PutLoginClientPf(ClienteModel clientePf)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PutLoginClientPf", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CPF", clientePf.Cpf);
                        cmd.Parameters.AddWithValue("@SENHA", clientePf.Senha);
                        int a = cmd.ExecuteNonQuery();
                        if (a == 1)
                        {
                            codeReturn = "Ok";
                            return codeReturn;
                        }
                        else
                        {
                            codeReturn = "falha";
                            return codeReturn;
                        }

                    }
                    catch (SqlException ex)
                    {
                        codeReturn = "falha";
                        return codeReturn;
                    }
                    return codeReturn;

                }
            }
        }
        public string PutLoginClientPj(ClienteModel clientePj)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PutLoginClientPJ", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CNPJ", clientePj.Cnpj);
                        cmd.Parameters.AddWithValue("@SENHA", clientePj.Senha);
                        int a = cmd.ExecuteNonQuery();
                        if (a == 1)
                        {
                            codeReturn = "Ok";
                            return codeReturn;
                        }
                        else
                        {
                            codeReturn = "falha";
                            return codeReturn;
                        }
                    }
                    catch (Exception)
                    {
                        codeReturn = "falha";
                        return codeReturn;
                    }

                }
            }
        }
        public void ChangeStatusClientById(ClienteModel cliente)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("ChangeStatusClientById", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", cliente.Id);
                    cmd.Parameters.AddWithValue("@STATUS", cliente.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public string DeleteClient(int id)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("DeleteClient", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            codeReturn = "Ok";
                            return codeReturn;
                        }
                    }
                    catch (SqlException ex)
                    {

                        if (ex.Number == 2601)
                        {
                            codeReturn = "Não foi possível realizar o cadastro";
                            return codeReturn;
                        }
                        else if (ex.Number == 2627)
                        {
                            codeReturn = "Não foi possível realizar o cadastro";
                            return codeReturn;
                        }
                    }
                    return codeReturn;
                }
            }
        }

        public List<ClientePjModel> GetAllClientsPj()
        {
            List<ClientePjModel> clientes = new List<ClientePjModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetAllClientsPj", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var cliente = new ClientePjModel();
                                cliente.Id = (int)reader["cli_id"];
                                cliente.Email = reader["cli_email"].ToString();
                                cliente.Senha = reader["cli_senha"].ToString();
                                cliente.Cep = reader["cli_cep"].ToString();
                                cliente.Logradouro = reader["cli_logradouro"].ToString();
                                cliente.Telefone = reader["cli_telefone"].ToString();
                                cliente.RazaoSocial = reader["cli_razaoSocial"].ToString();
                                cliente.ContratoSocial = reader["cli_contratoSocial"].ToString();
                                cliente.Cnpj = reader["cli_cnpj"].ToString();
                                cliente.DataCriacao = reader["cli_dataCriacao"].ToString();
                                cliente.TipoCliente = (TipoCliente)reader["cli_tipoCliente"];
                                cliente.Status = (Status)reader["cli_status"];
                                clientes.Add(cliente);
                            }
                        }
                    }
                }
            }
            return clientes;
        }

        public List<ClientePfModel> GetAllClientsPf()
        {
            List<ClientePfModel> clientes = new List<ClientePfModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetAllClientsPf", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var cliente = new ClientePfModel();
                                cliente.Id = (int)reader["cli_id"];
                                cliente.Email = reader["cli_email"].ToString();
                                cliente.Senha = reader["cli_senha"].ToString();
                                cliente.Cep = reader["cli_cep"].ToString();
                                cliente.Logradouro = reader["cli_logradouro"].ToString();
                                cliente.Telefone = reader["cli_telefone"].ToString();
                                cliente.Nome = reader["cli_nome"].ToString();
                                cliente.Cpf = reader["cli_cpf"].ToString();
                                cliente.Cnh = reader["cli_cnh"].ToString();
                                cliente.Rg = reader["cli_rg"].ToString();
                                cliente.DataNascimento = reader["cli_dataNascimento"].ToString();
                                cliente.EstadoCivil = (EstadoCivil)reader["cli_estadoCivil"];
                                cliente.Sexo = (Sexo)reader["cli_status"];
                                cliente.TipoCliente = (TipoCliente)reader["cli_tipoCliente"];
                                cliente.Status = (Status)reader["cli_status"];
                                clientes.Add(cliente);
                            }
                        }
                    }
                }
            }
            return clientes;
        }
    }
}


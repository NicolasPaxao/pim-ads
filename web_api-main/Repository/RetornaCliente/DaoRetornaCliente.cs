using System.Data.SqlClient;
using System.Data;
using web_api.Data;
using web_api.Enums;
using web_api.Models;
using web_api.Repository.Automovel;
using web_api.Repository.Cliente;
using web_api.Repository.Assistencia;
using web_api.Repository.Cobertura;
using web_api.Repository.Planos;
using web_api.Repository.Apolice;
using System.Globalization;

namespace web_api.Repository.RetornaCliente
{
    public class DaoRetornaCliente : IDaoRetornaCliente
    {
        private readonly DataContext _dataContext;

        public DaoRetornaCliente(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ReturnClienteModel ReturnClientProperties(string email, string senha)
        {
            ClienteModel c = new ClienteModel();
            List<RetornaApolicesModel> apolices = new List<RetornaApolicesModel>();
            List<AssistenciaModel> assistencias = new List<AssistenciaModel>();
            List<CoberturaModel> coberturas = new List<CoberturaModel>();
            ReturnClienteModel retorna = new ReturnClienteModel();

            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("ReturnClient", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var automovel = new AutomovelModel();
                                var assistencia = new AssistenciaModel();
                                var apolice = new RetornaApolicesModel();
                                var cobertura = new CoberturaModel();
                                apolice.Id = (int)reader["apol_id"];
                                apolice.PlanoId = (int)reader["plan_id"];
                                if (reader["cli_nome"] != null)
                                    apolice.ClienteNome = reader["cli_nome"].ToString();
                                else
                                    apolice.ClienteNome = reader["cli_razaoSocial"].ToString();
                                apolice.PlanoNome = (string)reader["plan_nomePlano"];
                                apolice.PlanoValor = (decimal)reader["plan_valor"];
                                apolice.FormaPagamento = (FormaPagamento)reader["apol_formaPagamento"];
                                apolice.DataCriacao = (DateTime)reader["apol_dataCriacaoApolice"];
                                apolice.TempoVigencia = (int)reader["apol_tempoVigencia"];
                                automovel.Id = (int)reader["auto_id"];
                                automovel.IdCliente = (int)reader["auto_cli_id"];
                                automovel.Modelo = (string)reader["auto_modelo"];
                                automovel.Marca = (string)reader["auto_marca"];
                                automovel.AnoModelo = (string)reader["auto_anoModelo"];
                                automovel.Cor = (string)reader["auto_cor"];
                                automovel.Renavam = (string)reader["auto_renavam"];
                                automovel.NumeroMotor = (string)reader["auto_numeroMotor"];
                                automovel.Placa = (string)reader["auto_placa"];
                                automovel.Crlv = (string)reader["auto_crlv"];
                                automovel.Status = (Status)reader["auto_status"];

                                apolice.Automovel = automovel;

                                if (apolices.Count == 0)
                                    apolices.Add(apolice);
                                else
                                {
                                    var hasApolicesEqual = apolices.Find((e) => e.Id == apolice.Id);
                                    if (hasApolicesEqual == null)
                                    {
                                        apolices.Add(apolice);
                                    }
                                }

                                ClienteModel cliente = new ClienteModel();
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
                                cliente.RazaoSocial = reader["cli_razaoSocial"].ToString();
                                cliente.ContratoSocial = reader["cli_contratoSocial"].ToString();
                                cliente.Cnpj = reader["cli_cnpj"].ToString();
                                cliente.DataCriacao = reader["cli_dataCriacao"].ToString();
                                cliente.TipoCliente = (TipoCliente)reader["cli_tipoCliente"];
                                cliente.Status = (Status)reader["cli_status"];

                                c = cliente;
                                cliente = null;
                                apolice = null;
                            }
                            retorna.Cliente = c;
                            retorna.Apolices = apolices;
                        }
                    }
                }
            }
            return retorna;
        }
    }
}

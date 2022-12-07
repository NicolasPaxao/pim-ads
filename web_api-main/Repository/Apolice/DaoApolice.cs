using System.Data.SqlClient;
using System.Data;
using web_api.Data;
using web_api.Models;
using web_api.Enums;

namespace web_api.Repository.Apolice
{
    public class DaoApolice : IDaoApolice
    {
        private readonly DataContext _dataContext;

        public DaoApolice(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteApolice(int id)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("DeleteApolice", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ApolicesModel> GetAllApolices()
        {
            List<ApolicesModel> apolices = new List<ApolicesModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetAllApolices", (SqlConnection)con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var apolice = new ApolicesModel();
                                apolice.Id = (int)reader["apol_id"];
                                apolice.IdPlano = (int)reader["apol_plan_id"];
                                apolice.IdCliente = (int)reader["apol_cli_id"];
                                apolice.IdFuncionario = (int)reader["apol_fun_id"];
                                apolice.IdAutomovel = (int)reader["apol_auto_id"];
                                apolice.FormaPagamento = (FormaPagamento)reader["apol_formaPagamento"];
                                apolice.DataCriacaoApolice = (DateTime)reader["apol_dataCriacaoApolice"];
                                apolice.TempoVigencia = (int)reader["apol_tempoVigencia"];
                                apolices.Add(apolice);

                            }
                        }
                    }
                }
            }
            return apolices;
        }

        public string PostApolice(ApolicesModel apolice)
        {
            using (var con = _dataContext.DbConnection)
            {
                var codeReturn = "";
                using (SqlCommand cmd = new SqlCommand("PostApolice", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDPLANO", apolice.IdPlano);
                        cmd.Parameters.AddWithValue("@IDCLIENTE", apolice.IdCliente);
                        cmd.Parameters.AddWithValue("@IDAUTOMOVEL", apolice.IdAutomovel);
                        cmd.Parameters.AddWithValue("@IDFUNCIONARIO", apolice.IdFuncionario);
                        cmd.Parameters.AddWithValue("@FORMAPAGAMENTO", apolice.FormaPagamento);
                        cmd.Parameters.AddWithValue("@DATACRIACAOAPOLICE", DateTime.Now);
                        cmd.ExecuteNonQuery();
                        codeReturn = "Ok";
                        return codeReturn;
                    }
                    catch (SqlException ex )
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

        public List<GenerateApolice> GetApolicesByCarId()
        {
            List<GenerateApolice> apolices = new List<GenerateApolice>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetApolicesByCarId", (SqlConnection)con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var automovel = new AutomovelModel();
                                var apolice = new GenerateApolice();
                                apolice.Id = (int)reader["apol_id"];
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
                                if (reader["cli_nome"] != null)
                                {
                                    apolice.ClienteNome = reader["cli_nome"].ToString();
                                }
                                else
                                {
                                    apolice.ClienteNome = reader["cli_razaoSocial"].ToString();
                                }
                                apolice.PlanoNome = (string)reader["plan_nomePlano"];
                                apolice.PlanoValor = (decimal)reader["plan_valor"];
                                apolice.FormaPagamento = (FormaPagamento)reader["apol_formaPagamento"];
                                apolice.DataCriacao = (DateTime)reader["apol_dataCriacaoApolice"];
                                apolice.TempoVigencia = (int)reader["apol_tempoVigencia"];
                                apolices.Add(apolice);

                            }
                        }
                    }
                }
            }
            return apolices;
        }
    }
}

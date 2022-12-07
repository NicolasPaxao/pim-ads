using System.Data.SqlClient;
using System.Data;
using web_api.Data;
using web_api.Models;
using web_api.Enums;

namespace web_api.Repository.Planos
{
    public class DaoPlano : IDaoPlano
    {
        private readonly DataContext _dataContext;

        public DaoPlano(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeletePlano(int id)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("DeletePlano", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PlanosModel> GetAllPlanos()
        {
            List<PlanosModel> planos = new List<PlanosModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetAllPlanos", (SqlConnection)con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var plano = new PlanosModel();
                                plano.Id = (int)reader["plan_id"];
                                plano.NomePlano = (string)reader["plan_nomePlano"];
                                plano.Valor = (decimal)reader["plan_valor"];
                                plano.IdSeguradora = (int)reader["plan_segu_id"];
                                plano.TipoPlano = (TipoPlano)reader["plan_tipoPlano"];
                                plano.Status = (Status)reader["plan_status"];
                                planos.Add(plano);

                            }
                        }
                    }
                }
            }
            return planos;
        }

        public string PostPlano(PlanosModel plano)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PostPlano", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NOMEPLANO", plano.NomePlano);
                        cmd.Parameters.AddWithValue("@IDSEGURADORA", plano.IdSeguradora);
                        cmd.Parameters.AddWithValue("@VALOR", plano.Valor);
                        cmd.Parameters.AddWithValue("@TIPOPLANO", plano.TipoPlano);
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

        public void PutPlano(PlanosModel plano)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PutPlano", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", plano.Id);
                    cmd.Parameters.AddWithValue("@NOMEPLANO", plano.NomePlano);
                    cmd.Parameters.AddWithValue("@VALOR", plano.Valor);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

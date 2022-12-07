using System.Data.SqlClient;
using System.Data;
using web_api.Data;
using web_api.Models;
using web_api.Enums;
using System.Numerics;

namespace web_api.Repository.Cobertura
{
    public class DaoCobertura : IDaoCobertura
    {
        private readonly DataContext _dataContext;

        public DaoCobertura(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteCobertura(int id)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("DeleteCobertura", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<CoberturaModel> GetAllCoberturas()
        {
            List<CoberturaModel> coberturas = new List<CoberturaModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetAllCoberturas", (SqlConnection)con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var cobertura = new CoberturaModel();
                                cobertura.Id = (int)reader["cober_id"];
                                cobertura.IdPlano = (int)reader["cober_plan_id"];
                                cobertura.Nome = (string)reader["cober_nome"];
                                cobertura.Descriacao = (string)reader["cober_descricao"];
                                cobertura.Indenizacao = (decimal)reader["cober_indenizacao"];
                                coberturas.Add(cobertura);

                            }
                        }
                    }
                }
            }
            return coberturas;
        }

        public string PostCobertura(CoberturaModel cobertura)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PostCobertura", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDPLANO", cobertura.IdPlano);
                        cmd.Parameters.AddWithValue("@NOME", cobertura.Nome);
                        cmd.Parameters.AddWithValue("@DESCRICAO", cobertura.Descriacao);
                        cmd.Parameters.AddWithValue("@INDENIZACAO", cobertura.Indenizacao);
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

        public void PutCobertura(CoberturaModel cobertura)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PutCobertura", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", cobertura.IdPlano);
                    cmd.Parameters.AddWithValue("@DESCRICAO", cobertura.Descriacao);
                    cmd.Parameters.AddWithValue("@INDENIZACAO", cobertura.Indenizacao);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

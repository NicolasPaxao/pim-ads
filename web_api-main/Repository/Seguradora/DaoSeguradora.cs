using System.Data.SqlClient;
using System.Data;
using web_api.Data;
using web_api.Models;
using web_api.Enums;

namespace web_api.Repository.Seguradora
{
    public class DaoSeguradora : IDaoSeguradora
    {
        private readonly DataContext _dataContext;

        public DaoSeguradora(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteSeguradora(int id)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("DeleteSeguradora", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<SeguradoraModel> GetAllSeguradoras()
        {
            List<SeguradoraModel> seguradoras = new List<SeguradoraModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetAllSeguradoras", (SqlConnection)con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var seguradora = new SeguradoraModel();
                                seguradora.Id = (int)reader["segu_id"];
                                seguradora.RazaoSocial = (string)reader["segu_razaoSocial"];
                                seguradora.Cnpj = (string)reader["segu_cnpj"];
                                seguradora.ContratoSocial = (string)reader["segu_contratoSocial"];
                                seguradora.Email = (string)reader["segu_email"];
                                seguradora.Telefone = (string)reader["segu_telefone"];
                                seguradora.Cep = (string)reader["segu_cep"];
                                seguradora.Logradouro = (string)reader["segu_logradouro"];
                                seguradora.Status = (Status)reader["segu_status"];
                                seguradoras.Add(seguradora);

                            }
                        }
                    }
                }
            }
            return seguradoras;
        }

        public string PostSeguradora(SeguradoraModel seguradora)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PostSeguradora", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RAZAOSOCIAL", seguradora.RazaoSocial);
                        cmd.Parameters.AddWithValue("@CNPJ", seguradora.Cnpj);
                        cmd.Parameters.AddWithValue("@CONTRATOSOCIAL", seguradora.ContratoSocial);
                        cmd.Parameters.AddWithValue("@EMAIL", seguradora.Email);
                        cmd.Parameters.AddWithValue("@TELEFONE", seguradora.Telefone);
                        cmd.Parameters.AddWithValue("@CEP", seguradora.Cep);
                        cmd.Parameters.AddWithValue("@LOGRADOURO", seguradora.Logradouro);
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

        public void PutSeguradora(SeguradoraModel seguradora)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PutSeguradora", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", seguradora.Id);
                    cmd.Parameters.AddWithValue("@EMAIL", seguradora.Email);
                    cmd.Parameters.AddWithValue("@TELEFONE", seguradora.Telefone);
                    cmd.Parameters.AddWithValue("@CEP", seguradora.Cep);
                    cmd.Parameters.AddWithValue("@LOGRADOURO", seguradora.Logradouro);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

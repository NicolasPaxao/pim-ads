using System.Data.SqlClient;
using System.Data;
using web_api.Data;
using web_api.Models;

namespace web_api.Repository.Assistencia
{
    public class DaoAssistencia : IDaoAssistencia
    {
        private readonly DataContext _dataContext;

        public DaoAssistencia(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteAssistencia(int id)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("DeleteAssistencia", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AssistenciaModel> GetAllAssistencias()
        {
            List<AssistenciaModel> assistencias = new List<AssistenciaModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetAllAssistencias", (SqlConnection)con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var assistencia = new AssistenciaModel();
                                assistencia.Id = (int)reader["assist_id"];
                                assistencia.IdPlano = (int)reader["assist_plan_id"];
                                assistencia.Nome = (string)reader["assist_nome"];
                                assistencia.EmpresaSuporte = (string)reader["assist_empresaSuporte"];
                                assistencia.Descriacao = (string)reader["assist_descricao"];
                                assistencia.Contato = (string)reader["assist_contato"];
                                assistencias.Add(assistencia);

                            }
                        }
                    }
                }
            }
            return assistencias;
        }

        public string PostAssistencia(AssistenciaModel assistencia)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PostAssistencia", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDPLANO", assistencia.IdPlano);
                        cmd.Parameters.AddWithValue("@DESCRICAO", assistencia.Descriacao);
                        cmd.Parameters.AddWithValue("@CONTATO", assistencia.Contato);
                        cmd.Parameters.AddWithValue("@EMPRESASUPORTE ", assistencia.EmpresaSuporte);
                        cmd.Parameters.AddWithValue("@NOME ", assistencia.Nome);
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

        public void PutAssistencia(AssistenciaModel assistencia)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PutAssistencia", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", assistencia.IdPlano);
                    cmd.Parameters.AddWithValue("@DESCRICAO", assistencia.Descriacao);
                    cmd.Parameters.AddWithValue("@CONTATO", assistencia.Contato);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

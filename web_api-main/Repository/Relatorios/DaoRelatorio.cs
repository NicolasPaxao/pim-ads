using System.Data.SqlClient;
using System.Data;
using web_api.Data;
using web_api.Models;

namespace web_api.Repository.Relatorios
{
    public class DaoRelatorio : IDaoRelatorio
    {
        private readonly DataContext _dataContext;

        public DaoRelatorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<DesempenhoEmpModel> GetDesempenhoEmpList(string data)
        {
            List<DesempenhoEmpModel> desemp = new List<DesempenhoEmpModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("DesempenhoEmpresa", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DATA", data);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var desempenho = new DesempenhoEmpModel();
                                desempenho.IdApolice = (int)reader["apol_id"];
                                desempenho.ValorPlano = (decimal)reader["plan_valor"];
                                desempenho.DataCriacao = (DateTime)reader["apol_dataCriacaoApolice"];
                                desemp.Add(desempenho);

                            }
                        }
                    }
                }
            }
            return desemp;
        }

        public List<DesempenhoFuncModel> GetDesempenhoFuncList(string data, int id)
        {
            List<DesempenhoFuncModel> desemp = new List<DesempenhoFuncModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("DesempenhoFuncionario", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DATA", data);
                    cmd.Parameters.AddWithValue("@FUNCID", id);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var desempenho = new DesempenhoFuncModel();
                                desempenho.IdApolice = (int)reader["apol_id"];
                                desempenho.ValorPlano = (decimal)reader["plan_valor"];
                                desempenho.DataCriacao = (DateTime)reader["apol_dataCriacaoApolice"];
                                desempenho.FuncionarioNome = (string)reader["fun_nome"];
                                desemp.Add(desempenho);

                            }
                        }
                    }
                }
            }
            return desemp;
        }
    }
}

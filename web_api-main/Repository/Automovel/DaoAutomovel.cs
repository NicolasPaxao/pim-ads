using api_teste.Models;
using System.Data.SqlClient;
using System.Data;
using web_api.Data;
using web_api.Enums;
using web_api.Models;

namespace web_api.Repository.Automovel
{
    public class DaoAutomovel : IDaoAutomovel
    {
        private readonly DataContext _dataContext;

        public DaoAutomovel(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void ChangeAutomovelStatus(AutomovelModel automovel)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("ChangeStatusAutomovelById", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", automovel.Id);
                    cmd.Parameters.AddWithValue("@STATUS", automovel.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAutomovel(int id)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("DeleteAutomovel", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AutomovelModel> GetAllAutomoveis()
        {
            List<AutomovelModel> automoveis = new List<AutomovelModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetAllAutomoveis", (SqlConnection)con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var automovel = new AutomovelModel();
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
                                automoveis.Add(automovel);

                            }
                        }
                    }
                }
            }
            return automoveis;
        }

        public string PostAutomovel(AutomovelModel automovel)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PostAutomovel", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDCLIENTE", automovel.IdCliente);
                        cmd.Parameters.AddWithValue("@MODELO", automovel.Modelo);
                        cmd.Parameters.AddWithValue("@MARCA", automovel.Marca);
                        cmd.Parameters.AddWithValue("@ANOMODELO", automovel.AnoModelo);
                        cmd.Parameters.AddWithValue("@COR", automovel.Cor);
                        cmd.Parameters.AddWithValue("@NUMEROMOTOR", automovel.NumeroMotor);
                        cmd.Parameters.AddWithValue("@PLACA", automovel.Placa);
                        cmd.Parameters.AddWithValue("@RENAVAM", automovel.Renavam);
                        cmd.Parameters.AddWithValue("@CRLV", automovel.Crlv);
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

        public void PutAutomovel(AutomovelModel automovel)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PutAutomovel", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", automovel.Id);
                    cmd.Parameters.AddWithValue("@MODELO", automovel.Modelo);
                    cmd.Parameters.AddWithValue("@MARCA", automovel.Marca);
                    cmd.Parameters.AddWithValue("@ANOMODELO", automovel.AnoModelo);
                    cmd.Parameters.AddWithValue("@COR", automovel.Cor);
                    cmd.Parameters.AddWithValue("@NUMEROMOTOR", automovel.NumeroMotor);
                    cmd.Parameters.AddWithValue("@RENAVAM", automovel.Renavam);
                    cmd.Parameters.AddWithValue("@CRLV", automovel.Crlv);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

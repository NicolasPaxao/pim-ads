using api_teste.Models;
using System.Data;
using System.Data.SqlClient;
using web_api.Data;
using web_api.Enums;

namespace web_api.Repository.Funcionarios
{
    public class DaoFuncionario : IDaoFuncionario
    {
        private readonly DataContext _dataContext;

        public DaoFuncionario(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<FuncionarioModel> GetAllFuncionarios()
        {
            List<FuncionarioModel> funcionarios = new List<FuncionarioModel>();
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("GetAllFuncionarios", (SqlConnection)con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var funcionario = new FuncionarioModel();
                                funcionario.Id = (int)reader["fun_id"];
                                funcionario.Nome = (string)reader["fun_nome"];
                                funcionario.Email = (string)reader["fun_email"];
                                funcionario.Senha = (string)reader["fun_senha"];
                                funcionario.DataNascimento = reader["fun_dataNascimento"].ToString();
                                funcionario.DataAdmissao = reader["fun_dataAdmissao"].ToString();
                                funcionario.Cpf = (string)reader["fun_cpf"];
                                funcionario.Rg = (string)reader["fun_rg"];
                                funcionario.Telefone = (string)reader["fun_telefone"];
                                funcionario.Cep = (string)reader["fun_cep"];
                                funcionario.Logradouro = (string)reader["fun_logradouro"];
                                funcionario.Cargo = (string)reader["fun_cargo"];
                                funcionario.Sexo = (Sexo)reader["fun_sexo"];
                                funcionario.Salario = (decimal)reader["fun_salario"];
                                funcionario.EstadoCivil = (EstadoCivil)reader["fun_estadoCivil"];
                                funcionario.Status = (Status)reader["fun_status"];
                                funcionarios.Add(funcionario);

                            }
                        }
                    }
                }
            }
            return funcionarios;
        }

        public string PostFuncionario(FuncionarioModel funcionario)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PostFuncionario", (SqlConnection)con))
                {

                    try
                    {
                        return codeReturn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NOME", funcionario.Nome);
                        cmd.Parameters.AddWithValue("@EMAIL", funcionario.Email);
                        cmd.Parameters.AddWithValue("@DATAADMISSAO", funcionario.DataAdmissao);
                        cmd.Parameters.AddWithValue("@DATANASCIMENTO", funcionario.DataNascimento);
                        cmd.Parameters.AddWithValue("@CPF", funcionario.Cpf);
                        cmd.Parameters.AddWithValue("@RG", funcionario.Rg);
                        cmd.Parameters.AddWithValue("@TELEFONE", funcionario.Telefone);
                        cmd.Parameters.AddWithValue("@CEP", funcionario.Cep);
                        cmd.Parameters.AddWithValue("@LOGRADOURO ", funcionario.Logradouro);
                        cmd.Parameters.AddWithValue("@CARGO", funcionario.Cargo);
                        cmd.Parameters.AddWithValue("@SEXO", funcionario.Sexo);
                        cmd.Parameters.AddWithValue("@SALARIO", funcionario.Salario);
                        cmd.Parameters.AddWithValue("@ESTADOCIVIL", funcionario.EstadoCivil);
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

        public string PutFuncionario(FuncionarioModel funcionario)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("PutFuncionario", (SqlConnection)con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", funcionario.Id);
                        cmd.Parameters.AddWithValue("@EMAIL", funcionario.Email);
                        cmd.Parameters.AddWithValue("@SENHA", funcionario.Senha);
                        cmd.Parameters.AddWithValue("@TELEFONE", funcionario.Telefone);
                        cmd.Parameters.AddWithValue("@CARGO", funcionario.Cargo);
                        cmd.Parameters.AddWithValue("@CEP", funcionario.Cep);
                        cmd.Parameters.AddWithValue("@LOGRADOURO ", funcionario.Logradouro);
                        cmd.Parameters.AddWithValue("@SALARIO", funcionario.Salario);
                        cmd.Parameters.AddWithValue("@ESTADOCIVIL", funcionario.EstadoCivil);
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
        public void ChangeFuncionarioStatus(FuncionarioModel funcionario)
        {
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("ChangeFuncionarioStatus", (SqlConnection)con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", funcionario.Id);
                    cmd.Parameters.AddWithValue("@STATUS", funcionario.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string DeleteFuncionario(int id)
        {
            var codeReturn = "";
            using (var con = _dataContext.DbConnection)
            {
                using (SqlCommand cmd = new SqlCommand("DeleteFuncionario", (SqlConnection)con))
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
    }

}

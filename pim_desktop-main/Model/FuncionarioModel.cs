using pim_desktop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Model
{
    public class FuncionarioModel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? DataNascimento { get; set; }
        public string? DataAdmissao { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public string? Telefone { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Cargo { get; set; }
        public decimal? Salario { get; set; }
        public Sexo? Sexo { get; set; }
        public EstadoCivil? EstadoCivil { get; set; }
        public Status? Status { get; set; }

    }
}

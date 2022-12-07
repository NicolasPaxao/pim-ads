using pim_desktop.Components;

using pim_desktop.Enums;
using pim_desktop.Model;
using pim_desktop.Repository.FuncionarioRepository;
using pim_desktop.Validators;
using pim_desktop.Views.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace pim_desktop.Views.RecursosHumanos
{
    public partial class CrudFuncionarioView : Form
    {
        public FormularioStatus FormularioStatus { get; set; }
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        FuncionarioModel funcionarioModel = new FuncionarioModel();

        public CrudFuncionarioView()
        {
            InitializeComponent();
            InitFormulario();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                funcionarioModel.Nome = nameInput.Text;
                funcionarioModel.Email = emailInput.Text;
                funcionarioModel.Telefone = telefoneInput.Text;
                funcionarioModel.Cep = cepInput.Text;
                funcionarioModel.Rg = rgInput.Text;
                funcionarioModel.Cpf = cpfInput.Text;
                funcionarioModel.Logradouro = logradouroInput.Text;
                funcionarioModel.Cargo = cargoInput.Text;
                funcionarioModel.Sexo = (Sexo)sexoDropdown.SelectedItem;
                funcionarioModel.Salario = Decimal.Parse(salarioInput.Text);
                funcionarioModel.EstadoCivil = (EstadoCivil)ecDropdown.SelectedIndex;
                funcionarioModel.DataNascimento = dtNascPicker.Text;
                funcionarioModel.DataAdmissao = dtAdmissaoPicker.Text;
                if (this.FormularioStatus == FormularioStatus.Atualizacao)
                {
                    idBox.Enabled = true;
                    this.FormularioStatus = FormularioStatus.Cadastro;
                    funcionarioRepository.AlterarDadosFuncionario(funcionarioModel);
                    Clear();
                    ChangeStatus();
                }
                else if (this.FormularioStatus == FormularioStatus.Cadastro)
                {
                    funcionarioRepository.PostFuncionario(funcionarioModel);
                    Clear();
                    ChangeStatus();
                }
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            new DeleteModal(funcionarioRepository.DeletarFuncionario).Show();
            this.GetList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FormularioStatus = FormularioStatus.Cadastro;
            Clear();
            ChangeStatus();

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.FormularioStatus = FormularioStatus.Atualizacao;
            ChangeStatus();

        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            Clear();
            GetList();
        }

        private async void searchById_Click(object sender, EventArgs e)
        {
            if (Validadores.NumberValidator(idBox.Text))
            {
                funcionarioModel = await funcionarioRepository.GetFuncionarioById(int.Parse(idBox.Text));
                nameInput.Text = funcionarioModel.Nome;
                emailInput.Text = funcionarioModel.Email;
                telefoneInput.Text = funcionarioModel.Telefone;
                cepInput.Text = funcionarioModel.Cep;
                rgInput.Text = funcionarioModel.Rg;
                cpfInput.Text = funcionarioModel.Cpf;
                telefoneInput.Text = funcionarioModel.Telefone;
                logradouroInput.Text = funcionarioModel.Logradouro;
                cargoInput.Text = funcionarioModel.Cargo;
                sexoDropdown.SelectedItem = funcionarioModel.Sexo;
                ecDropdown.SelectedItem = funcionarioModel.EstadoCivil;
                salarioInput.Text = funcionarioModel.Salario.ToString();
                dtNascPicker.Text = funcionarioModel.DataNascimento;
                dtAdmissaoPicker.Text = funcionarioModel.DataAdmissao;
            }
            else
            {
                new CreateResponseModal("INSIRA UM ID VÁLIDO").Show();
            }

        }

        private bool ValidarForm()
        {
            bool formValido;
            if (!Validadores.TextValidator(nameInput.Text))
            {
                new CreateResponseModal("INSIRA UM NOME VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.EmailValidator(emailInput.Text))
            {
                new CreateResponseModal("INSIRA UM E-MAIL VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.RgValidator(rgInput.Text))
            {
                new CreateResponseModal("INSIRA UM RG VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.CpfValidator(cpfInput.Text))
            {
                new CreateResponseModal("INSIRA UM CPF VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.MenorDeIdadeValidator(DateTime.Parse(dtNascPicker.Text)))
            {
                new CreateResponseModal("O FUNCIONÁRIO DEVE SER\nMAIOR DE IDADE!").Show();
                formValido = false;
            }
            else if (!Validadores.TextValidator(dtAdmissaoPicker.Text))
            {
                new CreateResponseModal("INSIRA UM DATA DE ADMISSÃO\n VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.TelefoneValidator(telefoneInput.Text))
            {
                new CreateResponseModal("INSIRA UM TELEFONE VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.TextValidator(cargoInput.Text))
            {
                new CreateResponseModal("INSIRA UM CARGO VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.NumberValidator(salarioInput.Text))
            {
                new CreateResponseModal("INSIRA UM SALÁRIO VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.SexoValidator(sexoDropdown))
            {
                new CreateResponseModal("INSIRA UM SEXO VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.EstadoCivilValidator(ecDropdown))
            {
                new CreateResponseModal("INSIRA UM ESTADO CIVIL\n VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.CepValidator(cepInput.Text))
            {
                new CreateResponseModal("INSIRA UM CEP VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.TextValidator(logradouroInput.Text))
            {
                new CreateResponseModal("INSIRA UM LOGRADOURO VÁLIDO!").Show();
                formValido = false;
            }
            else
                formValido = true;

            return formValido;
        }

        private void ChangeStatus()
        {
            if (this.FormularioStatus == FormularioStatus.Atualizacao)
            {
                idBox.Enabled = true;
                searchById.Visible = true;
                sexoDropdown.Enabled = false;
                nameInput.Enabled = false;
                rgInput.Enabled = false;
                cpfInput.Enabled = false;
                dtAdmissaoPicker.Enabled = false;
                dtNascPicker.Enabled = false;
            }
            else if (this.FormularioStatus == FormularioStatus.Cadastro)
            {
                idBox.Enabled = false;
                searchById.Visible = false;
                sexoDropdown.Enabled = true;
                nameInput.Enabled = true;
                rgInput.Enabled = true;
                cpfInput.Enabled = true;
                dtAdmissaoPicker.Enabled = true;
                dtNascPicker.Enabled = true;
            }
        }

        private void Clear()
        {
            idBox.Text = "";
            nameInput.Text = "";
            emailInput.Text = "";
            telefoneInput.Text = "";
            cepInput.Text = "";
            rgInput.Text = "";
            cpfInput.Text = "";
            telefoneInput.Text = "";
            logradouroInput.Text = "";
            cargoInput.Text = "";
            sexoDropdown.SelectedIndex = -1;
            salarioInput.Text = "";
            ecDropdown.SelectedIndex = -1;
            dtNascPicker.Text = "";
            dtAdmissaoPicker.Text = "";
            funcionarioModel = null;
        }

        private void InitFormulario()
        {
            this.FormularioStatus = FormularioStatus.Cadastro;
            GetList();
            ecDropdown.DataSource = Enum.GetValues(typeof(EstadoCivil));
            sexoDropdown.DataSource = Enum.GetValues(typeof(Sexo));
            sexoDropdown.SelectedIndex = -1;
            ecDropdown.SelectedIndex = -1;
            funcionariosList.Font = new Font("Segoe UI", 12);
            ChangeStatus();
        }

        private async void GetList()
        {
            var myGrid = new DataGridCustom();
            myGrid.EmptyResultText = "SEM DADOS PARA MOSTRAR";
            myGrid.Dock = DockStyle.Fill;
            myGrid.DataSource = new List<string>();
            try
            {
                var lst = await funcionarioRepository.GetAllFuncionarios();
                if (lst.Count == 0)
                    funcionariosList.Controls.Add(myGrid);
                else
                    funcionariosList.DataSource = lst;
            }
            catch (Exception e)
            {
                new CreateResponseModal("ERRO: \n" + e.Message).Show();
            }
        }

        #region ViewsNA
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void funcionariosList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void ecDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sexoDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logradouroInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cepInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion

        private void CrudFuncionarioView_Load(object sender, EventArgs e)
        {

        }
    }
}

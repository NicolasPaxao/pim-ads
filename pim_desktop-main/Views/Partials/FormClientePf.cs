using pim_desktop.Constants;
using pim_desktop.Enums;
using pim_desktop.Model;
using pim_desktop.Repository.ClienteRepository;
using pim_desktop.Validators;
using pim_desktop.Views.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pim_desktop.Views.Partials
{
    public partial class FormClientePf : Form
    {
        public ClienteModel clienteModel = new ClienteModel();
        public ClienteRepository clienteRepository = new ClienteRepository();

        public FormClientePf()
        {
            InitializeComponent();
            InitFormulario();
        }

        private async void searchById_Click(object sender, EventArgs e)
        {
            clienteModel = await clienteRepository.GetClienteById(int.Parse(idBox.Text));
            if (clienteModel.TipoCliente == TipoCliente.Pessoa_Fisica)
            {
                nameInput.Text = clienteModel.Nome;
                cpfInput.Text = clienteModel.Cpf;
                rgInput.Text = clienteModel.Rg;
                cnhInput.Text = clienteModel.Cnh;
                sexoDropdown.SelectedItem = clienteModel.Sexo;
                ecDropdown.SelectedItem = clienteModel.EstadoCivil;
                telefoneInput.Text = clienteModel.Telefone;
                emailInput.Text = clienteModel.Email;
                dtNascPicker.Text = clienteModel.DataNascimento;
                cepInput.Text = clienteModel.Cep;
                logradouroInput.Text = clienteModel.Logradouro;
            }
            else
            {
                new CreateResponseModal("BUSQUE PELO TIPO DE CLIENTE CERTO!").Show();
            }

        }
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Consts.changeStatus = FormularioStatus.Cadastro;
            Clear();
            ChangeStatus();
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                clienteModel.EstadoCivil = (EstadoCivil)ecDropdown.SelectedIndex;
                clienteModel.Sexo = (Sexo)sexoDropdown.SelectedItem;
                clienteModel.Cep = cepInput.Text;
                clienteModel.Logradouro = logradouroInput.Text;
                clienteModel.Telefone = telefoneInput.Text;
                clienteModel.Email = emailInput.Text;
                clienteModel.DataNascimento = dtNascPicker.Text;
                clienteModel.Nome = nameInput.Text;
                clienteModel.Cpf = cpfInput.Text;
                clienteModel.Rg = rgInput.Text;
                clienteModel.Cnh = cnhInput.Text;

                if (Consts.changeStatus == FormularioStatus.Atualizacao)
                {
                    idBox.Enabled = true;
                    Consts.changeStatus = FormularioStatus.Cadastro;
                    clienteRepository.AlterarDadosCliente(clienteModel);
                    Clear();
                    ChangeStatus();
                }
                else if (Consts.changeStatus == FormularioStatus.Cadastro)
                {
                    clienteRepository.PostClientePf(clienteModel);
                    Clear();
                    ChangeStatus();
                }
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
                new CreateResponseModal("INSIRA UM EMAIL VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.CpfValidator(cpfInput.Text))
            {
                new CreateResponseModal("INSIRA UM CPF VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.RgValidator(rgInput.Text))
            {
                new CreateResponseModal("INSIRA UM RG VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.MenorDeIdadeValidator(DateTime.Parse(dtNascPicker.Text)))
            {
                new CreateResponseModal("O CLIENTE DEVE SER\nMAIOR DE IDADE!").Show();
                formValido = false;
            }
            else if (!Validadores.ComboxValidator(sexoDropdown))
            {
                new CreateResponseModal("INSIRA UM SEXO VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.ComboxValidator(ecDropdown))
            {
                new CreateResponseModal("INSIRA UM ESTADO CIVIL VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.TelefoneValidator(telefoneInput.Text))
            {
                new CreateResponseModal("INSIRA UM TELEFONE VÁLIDO!").Show();
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
            if (Consts.changeStatus == FormularioStatus.Atualizacao)
            {
                idBox.Enabled = true;
                searchById.Visible = true;
                nameInput.Enabled = false;
                cpfInput.Enabled = false;
                rgInput.Enabled = false;
                dtNascPicker.Enabled = false;
                sexoDropdown.Enabled = false;
            }
            else if (Consts.changeStatus == FormularioStatus.Cadastro)
            {
                idBox.Enabled = false;
                searchById.Visible = false;
                nameInput.Enabled = true;
                cpfInput.Enabled = true;
                rgInput.Enabled = true;
                dtNascPicker.Enabled = true;
                sexoDropdown.Enabled = true;
            }
        }

        private void Clear()
        {
            idBox.Text = "";
            telefoneInput.Text = "";
            nameInput.Text = "";
            cpfInput.Text = "";
            cnhInput.Text = "";
            rgInput.Text = "";
            emailInput.Text = "";
            dtNascPicker.Text = "";
            sexoDropdown.SelectedIndex = -1;
            ecDropdown.SelectedIndex = -1;
            cepInput.Text = "";
            logradouroInput.Text = "";
        }

        private void InitFormulario()
        {
            ChangeStatus();
            ecDropdown.DataSource = Enum.GetValues(typeof(EstadoCivil));
            sexoDropdown.DataSource = Enum.GetValues(typeof(Sexo));
            sexoDropdown.SelectedIndex = -1;
            ecDropdown.SelectedIndex = -1;
        }

        #region ViewsNA
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                //funcionarioModel.Nome = nameInput.Text;
                //funcionarioModel.Telefone = telefoneInput.Text;
                if (Consts.changeStatus == FormularioStatus.Atualizacao)
                {
                    idBox.Enabled = true;
                    Consts.changeStatus = FormularioStatus.Cadastro;
                    //funcionarioRepository.AlterarDadosFuncionario(funcionarioModel);
                    Clear();
                    ChangeStatus();
                }
                else if (Consts.changeStatus == FormularioStatus.Cadastro)
                {
                    //funcionarioRepository.PostFuncionario(funcionarioModel);
                    Clear();
                    ChangeStatus();
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Consts.changeStatus = FormularioStatus.Cadastro;
            Clear();
            ChangeStatus();

        }
        #endregion
    }
}

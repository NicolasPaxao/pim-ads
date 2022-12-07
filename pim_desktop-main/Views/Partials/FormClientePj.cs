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
    public partial class FormClientePj : Form
    {
        public ClienteModel clienteModel = new ClienteModel();
        public ClienteRepository clienteRepository = new ClienteRepository();

        public FormClientePj()
        {
            InitializeComponent();
            InitFormulario();
        }

        private async void searchById_Click(object sender, EventArgs e)
        {
            if (Validadores.NumberValidator(idBox.Text))
            {
                clienteModel = await clienteRepository.GetClienteById(int.Parse(idBox.Text));
                if (clienteModel.TipoCliente == TipoCliente.Pessoa_Juridica)
                {
                    razaoSocialInput.Text = clienteModel.RazaoSocial;
                    ctSocialInput.Text = clienteModel.ContratoSocial;
                    cnpjInput.Text = clienteModel.Cnpj;
                    telefoneInput.Text = clienteModel.Telefone;
                    emailInput.Text = clienteModel.Email;
                    dtCriacaoPicker.Text = clienteModel.DataCriacao;
                    cepInput.Text = clienteModel.Cep;
                    logradouroInput.Text = clienteModel.Logradouro;
                }
                else
                {
                    new CreateResponseModal("BUSQUE PELO TIPO DE CLIENTE CERTO!").Show();
                }
            }
            else
            {
                new CreateResponseModal("INSIRA UM ID VÁLIDO").Show();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                clienteModel.RazaoSocial = razaoSocialInput.Text;
                clienteModel.ContratoSocial = ctSocialInput.Text;
                clienteModel.Cnpj = cnpjInput.Text;
                clienteModel.Telefone = telefoneInput.Text;
                clienteModel.Email = emailInput.Text;
                clienteModel.DataCriacao = dtCriacaoPicker.Text;
                clienteModel.Cep = cepInput.Text;
                clienteModel.Logradouro = logradouroInput.Text;

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
                    clienteRepository.PostClientePj(clienteModel);
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

        private bool ValidarForm()
        {
            bool formValido;
            if (!Validadores.TextValidator(razaoSocialInput.Text))
            {
                new CreateResponseModal("INSIRA UM NOME VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.NumberValidator(ctSocialInput.Text))
            {
                new CreateResponseModal("INSIRA UM CONTRATO VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.CnpjValidator(cnpjInput.Text))
            {
                new CreateResponseModal("INSIRA UM CNPJ VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.TelefoneValidator(telefoneInput.Text))
            {
                new CreateResponseModal("INSIRA UM TELEFONE VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.EmailValidator(emailInput.Text))
            {
                new CreateResponseModal("INSIRA UM E-MAIL VÁLIDO!").Show();
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
                razaoSocialInput.Enabled = false;
                ctSocialInput.Enabled = false;
                cnpjInput.Enabled = false;
                dtCriacaoPicker.Enabled = false;
            }
            else if (Consts.changeStatus == FormularioStatus.Cadastro)
            {
                idBox.Enabled = false;
                searchById.Visible = false;
                razaoSocialInput.Enabled = true;
                ctSocialInput.Enabled = true;
                cnpjInput.Enabled = true;
                dtCriacaoPicker.Enabled = true;
            }
        }

        private void Clear()
        {
            idBox.Text = "";
            telefoneInput.Text = "";
            razaoSocialInput.Text =  "";
            ctSocialInput.Text = "";
            cnpjInput.Text = "";
            emailInput.Text = "";
            dtCriacaoPicker.Text = "";
            cepInput.Text = "";
            logradouroInput.Text = "";
        }

        private void InitFormulario()
        {
            ChangeStatus();
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

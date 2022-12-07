using pim_desktop.Components;
using pim_desktop.Enums;
using pim_desktop.Model;
using pim_desktop.Repository.SeguradoraRepository;
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

namespace pim_desktop.Views
{
    public partial class CrudSeguradora : Form
    {
        public FormularioStatus FormularioStatus { get; set; }
        private SeguradoraModel seguradoraModel = new SeguradoraModel();
        private SeguradoraRepository seguradoraRepository = new SeguradoraRepository();

        public CrudSeguradora()
        {
            InitializeComponent();
            InitFormulario();
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            Clear();
            GetList();

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            this.FormularioStatus = FormularioStatus.Atualizacao;
            ChangeStatus();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            new DeleteModal(seguradoraRepository.DeletarSeguradora).Show();
            GetList();

        }

        private async void searchById_Click(object sender, EventArgs e)
        {
            if (Validadores.NumberValidator(idBox.Text))
            {
                seguradoraModel = await seguradoraRepository.GetSeguradoraById(int.Parse(idBox.Text));
                razaoInput.Text = seguradoraModel.RazaoSocial;
                cnpjInput.Text = seguradoraModel.Cnpj;
                contratoInput.Text = seguradoraModel.ContratoSocial;
                telefoneInput.Text = seguradoraModel.Telefone;
                emailInput.Text = seguradoraModel.Email;
                cepInput.Text = seguradoraModel.Cep;
                logradouroInput.Text = seguradoraModel.Logradouro;
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
                seguradoraModel.RazaoSocial = razaoInput.Text;
                seguradoraModel.Cnpj = cnpjInput.Text;
                seguradoraModel.ContratoSocial = contratoInput.Text;
                seguradoraModel.Telefone = telefoneInput.Text;
                seguradoraModel.Email = emailInput.Text;
                seguradoraModel.Cep = cepInput.Text;
                seguradoraModel.Logradouro = logradouroInput.Text;
                if (this.FormularioStatus == FormularioStatus.Atualizacao)
                {
                    idBox.Enabled = true;
                    this.FormularioStatus = FormularioStatus.Cadastro;
                    seguradoraRepository.AlterarDadosSeguradora(seguradoraModel);
                    Clear();
                    ChangeStatus();
                }
                else if (this.FormularioStatus == FormularioStatus.Cadastro)
                {
                    seguradoraRepository.PostSeguradora(seguradoraModel);
                    Clear();
                    ChangeStatus();
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FormularioStatus = FormularioStatus.Cadastro;
            Clear();
            ChangeStatus();

        }

        private bool ValidarForm()
        {
            bool formValido;
            if (!Validadores.TextValidator(razaoInput.Text))
            {
                new CreateResponseModal("INSIRA UMA RAZÃO SOCIAL VÁLIDA!").Show();
                formValido = false;
            }
            else if (!Validadores.CnpjValidator(cnpjInput.Text))
            {
                new CreateResponseModal("INSIRA UM CNPJ VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.TextValidator(contratoInput.Text))
            {
                new CreateResponseModal("INSIRA UM CONTRATO SOCIAL VÁLIDO!").Show();
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
            if (this.FormularioStatus == FormularioStatus.Atualizacao)
            {
                idBox.Enabled = true;
                searchById.Visible = true;
                razaoInput.Enabled = false;
                contratoInput.Enabled = false;
                cnpjInput.Enabled = false;
            }
            else if (this.FormularioStatus == FormularioStatus.Cadastro)
            {
                idBox.Enabled = false;
                searchById.Visible = false;
                razaoInput.Enabled = true;
                contratoInput.Enabled = true;
                cnpjInput.Enabled = true;
            }
        }

        private void Clear()
        {
            idBox.Text = "";
            razaoInput.Text = "";
            telefoneInput.Text = "";
            cnpjInput.Text = "";
            contratoInput.Text = "";
            emailInput.Text = "";
            cepInput.Text = "";
            logradouroInput.Text = "";
        }

        private void InitFormulario()
        {
            this.FormularioStatus = FormularioStatus.Cadastro;
            GetList();
            seguradoraList.Font = new Font("Segoe UI", 12);
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
                var lst = await seguradoraRepository.GetAllSeguradoras();
                if (lst.Count == 0)
                seguradoraList.Controls.Add(myGrid);
                else
                   seguradoraList.DataSource = lst;
            }
            catch (Exception e)
            {
                new CreateResponseModal("ERRO: \n" + e.Message).Show();
            }
        }



        #region ViewsNA
        private void CrudSeguradora_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}

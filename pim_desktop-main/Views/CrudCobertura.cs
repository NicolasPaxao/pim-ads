using pim_desktop.Components;
using pim_desktop.Enums;
using pim_desktop.Model;
using pim_desktop.Repository.CoberturaRepository;
using pim_desktop.Repository.PlanoRepository;
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

namespace pim_desktop.Views.Comercial
{
    public partial class CrudCobertura : Form
    {
        public FormularioStatus FormularioStatus { get; set; }
        CoberturaModel coberturaModel = new CoberturaModel();
        CoberturaRepository coberturaRepository = new CoberturaRepository();
        private PlanoRepository planoRepository = new PlanoRepository();
        List<PlanoListModel> planoListModels = new List<PlanoListModel>();


        public CrudCobertura()
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
            new DeleteModal(coberturaRepository.DeletarCobertura).Show();
            GetList();

        }

        private async void searchById_Click(object sender, EventArgs e)
        {
            if (Validadores.NumberValidator(idBox.Text))
            {
                
                coberturaModel = await coberturaRepository.GetCoberturaById(int.Parse(idBox.Text));
                var plan = planoListModels.Find((e) => e.Id == coberturaModel.IdPlano);
                nameInput.Text = coberturaModel.Nome;
                indenizacaoInput.Text = coberturaModel.Indenizacao.ToString();
                descricaoInput.Text = coberturaModel.Descriacao;
                if (plan != null)
                    planoDropdown.SelectedItem = plan.Name;
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
                PlanoListModel plan = planoListModels.Find((e) => e.Name == planoDropdown.Text);
                coberturaModel.Nome = nameInput.Text;
                coberturaModel.Descriacao = descricaoInput.Text;
                coberturaModel.Indenizacao = decimal.Parse(indenizacaoInput.Text);
                if (plan != null)
                    coberturaModel.IdPlano = plan.Id;
                if (this.FormularioStatus == FormularioStatus.Atualizacao)
                {
                    idBox.Enabled = true;
                    this.FormularioStatus = FormularioStatus.Cadastro;
                    coberturaRepository.AlterarDadosCobertura(coberturaModel);
                    Clear();
                    ChangeStatus();
                }
                else if (this.FormularioStatus == FormularioStatus.Cadastro)
                {
                    coberturaRepository.PostCobertura(coberturaModel);
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
            if (!Validadores.TextValidator(nameInput.Text))
            {
                new CreateResponseModal("INSIRA UM NOME VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.NumberValidator(indenizacaoInput.Text))
            {
                new CreateResponseModal("INSIRA UM NÚMERO(%) VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.ComboxValidator(planoDropdown))
            {
                new CreateResponseModal("INSIRA UM NÚMERO(%) VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.MuilLineValidator(descricaoInput.Text))
            {
                new CreateResponseModal("INSIRA UM TELEFONE VÁLIDO!").Show();
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
                nameInput.Enabled = false;
                planoDropdown.Enabled = false;
            }
            else if (this.FormularioStatus == FormularioStatus.Cadastro)
            {
                idBox.Enabled = false;
                searchById.Visible = false;
                nameInput.Enabled = true;
                planoDropdown.Enabled = true;
            }
        }

        private void Clear()
        {
            idBox.Text = "";
            nameInput.Text = "";
            planoDropdown.SelectedIndex = -1;
            indenizacaoInput.Text = "";
            descricaoInput.Text = "";

        }

        private async void InitFormulario()
        {
            var listTemp = await planoRepository.GetAllPlanos();
            listTemp.ForEach((e) => planoListModels.Add(new PlanoListModel(e.Id, e.NomePlano)));
            this.FormularioStatus = FormularioStatus.Cadastro;
            GetList();
            foreach (var item in planoListModels)
                planoDropdown.Items.Add(item.Name);
            this.FormularioStatus = FormularioStatus.Cadastro;
            GetList();
            planoDropdown.SelectedIndex = -1;
            coberturaList.Font = new Font("Segoe UI", 12);
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
                var lst = await coberturaRepository.GetAllCoberturas();
                if (lst.Count == 0)
                coberturaList.Controls.Add(myGrid);
                else
                    coberturaList.DataSource = lst;
            }
            catch (Exception e)
            {
                new CreateResponseModal("ERRO: \n" + e.Message).Show();
            }
        }



        #region ViewsNA
        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }
}

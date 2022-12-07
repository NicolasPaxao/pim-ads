using pim_desktop.Components;
using pim_desktop.Enums;
using pim_desktop.Model;
using pim_desktop.Repository.PlanoRepository;
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
    public partial class CrudPlano : Form
    {
        public FormularioStatus FormularioStatus { get; set; }
        PlanoModel planoModel = new PlanoModel();
        PlanoRepository planoRepository = new PlanoRepository();
        SeguradoraRepository seguradoraRepository = new SeguradoraRepository();
        List<SeguradoraListModel> seguradoraListModel = new List<SeguradoraListModel>();

        public CrudPlano()
        {
            InitializeComponent();
            InitFormulario();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FormularioStatus = FormularioStatus.Cadastro;
            Clear();
            ChangeStatus();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                SeguradoraListModel seg = seguradoraListModel.Find((e) => e.Name == seguradoraDropdown.Text);
                planoModel.NomePlano = nameInput.Text;
                if(seg != null)
                    planoModel.IdSeguradora = seg.Id;
                planoModel.TipoPlano = (TipoPlano)tipoPlanoDropdown.SelectedIndex;
                planoModel.Valor = decimal.Parse(vlPlanoInput.Text);
                if (this.FormularioStatus == FormularioStatus.Atualizacao)
                {
                    idBox.Enabled = true;
                    this.FormularioStatus = FormularioStatus.Cadastro;
                    planoRepository.AlterarDadosPlano(planoModel);
                    Clear();
                    ChangeStatus();
                }
                else if (this.FormularioStatus == FormularioStatus.Cadastro)
                {
                    planoRepository.PostPlano(planoModel);
                    Clear();
                    ChangeStatus();
                }
            }

        }

        private async void searchById_Click(object sender, EventArgs e)
        {
            if (Validadores.NumberValidator(idBox.Text))
            {
                planoModel = await planoRepository.GetPlanoById(int.Parse(idBox.Text));
                var seg = seguradoraListModel.Find((e) => e.Id == planoModel.IdSeguradora);
                nameInput.Text = planoModel.NomePlano;
                tipoPlanoDropdown.SelectedItem = planoModel.TipoPlano;
                vlPlanoInput.Text = planoModel.Valor.ToString();
                if (seg != null)
                    seguradoraDropdown.SelectedItem = seg.Name;
            }
            else
            {
                new CreateResponseModal("INSIRA UM ID VÁLIDO").Show();
            }
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
            new DeleteModal(planoRepository.DeletarPlano).Show();
            GetList();

        }

        private bool ValidarForm()
        {
            bool formValido;
            if (!Validadores.TextValidator(nameInput.Text))
            {
                new CreateResponseModal("INSIRA UM NOME VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.ComboxValidator(seguradoraDropdown))
            {
                new CreateResponseModal("INSIRA UMA SEGURADORA VÁLIDA!").Show();
                formValido = false;
            }
            else if (!Validadores.NumberValidator(vlPlanoInput.Text))
            {
                new CreateResponseModal("INSIRA UM VALOR VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.ComboxValidator(tipoPlanoDropdown))
            {
                new CreateResponseModal("INSIRA UM TIPO DE PLANO VÁLIDO!").Show();
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
                seguradoraDropdown.Enabled = false;
            }
            else if (this.FormularioStatus == FormularioStatus.Cadastro)
            {
                idBox.Enabled = false;
                searchById.Visible = false;
                nameInput.Enabled = true;
                seguradoraDropdown.Enabled = true;
            }
        }

        private void Clear()
        {
            idBox.Text = "";
            nameInput.Text = "";
            vlPlanoInput.Text = "";
            tipoPlanoDropdown.SelectedIndex = -1;
            seguradoraDropdown.SelectedIndex = -1;
        }

        private async void InitFormulario()
        {
            var listTemp = await seguradoraRepository.GetAllSeguradoras();
            listTemp.ForEach((e) => seguradoraListModel.Add(new SeguradoraListModel(e.Id, e.RazaoSocial)));
            this.FormularioStatus = FormularioStatus.Cadastro;
            GetList();
            foreach (var item in seguradoraListModel)
                seguradoraDropdown.Items.Add(item.Name);
            this.FormularioStatus = FormularioStatus.Cadastro;
            GetList();
            tipoPlanoDropdown.DataSource = Enum.GetValues(typeof(TipoPlano));
            tipoPlanoDropdown.SelectedIndex = -1;
            seguradoraDropdown.SelectedIndex = -1;
            planoList.Font = new Font("Segoe UI", 12);
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
                var lst = await planoRepository.GetAllPlanos();
                if (lst.Count == 0)
                planoList.Controls.Add(myGrid);
                else
                    planoList.DataSource = lst;
            }
            catch (Exception e)
            {
                new CreateResponseModal("ERRO: \n" + e.Message).Show();
            }
        }

    }
}

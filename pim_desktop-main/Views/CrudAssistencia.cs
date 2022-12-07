using pim_desktop.Components;
using pim_desktop.Enums;
using pim_desktop.Model;
using pim_desktop.Repository.AssistenciaRepository;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace pim_desktop.Views
{
    public partial class CrudAssistencia : Form
    {
        public FormularioStatus FormularioStatus { get; set; }
        private AssistenciaModel assistenciaModel = new AssistenciaModel();
        private AssistenciaRepository assistenciaRepository = new AssistenciaRepository();
        private PlanoRepository planoRepository = new PlanoRepository();
        List<PlanoListModel> planoListModels = new List<PlanoListModel>();
       
        public CrudAssistencia()
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
            new DeleteModal(assistenciaRepository.DeletarAssistencia).Show();
            GetList();

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            
            if (ValidarForm())
            {
                PlanoListModel plan = planoListModels.Find((e) => e.Name == planoDropdown.Text);
                assistenciaModel.Nome = nameInput.Text;
                assistenciaModel.EmpresaSuporte = empresaInput.Text;
                if (plan != null)
                {
                    assistenciaModel.IdPlano = plan.Id;
                }
                assistenciaModel.Contato = telefoneInput.Text;
                assistenciaModel.Descriacao = descricaoInput.Text;
                if (this.FormularioStatus == FormularioStatus.Atualizacao)
                {
                    idBox.Enabled = true;
                    this.FormularioStatus = FormularioStatus.Cadastro;
                    assistenciaRepository.AlterarDadosAssistencia(assistenciaModel);
                    Clear();
                    ChangeStatus();
                }
                else if (this.FormularioStatus == FormularioStatus.Cadastro)
                {
                    assistenciaRepository.PostAssistencia(assistenciaModel);
                    Clear();
                    ChangeStatus();
                }
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.FormularioStatus = FormularioStatus.Cadastro;
            Clear();
            ChangeStatus();
        }

        private async void searchById_Click(object sender, EventArgs e)
        {
            if (Validadores.NumberValidator(idBox.Text))
            {
                
                assistenciaModel = await assistenciaRepository.GetAssistenciaById(int.Parse(idBox.Text));
                var plan = planoListModels.Find((e) => e.Id == assistenciaModel.IdPlano);
                nameInput.Text = assistenciaModel.Nome;
                telefoneInput.Text = assistenciaModel.Contato;
                if(plan != null)
                    planoDropdown.SelectedItem = plan.Name;
                telefoneInput.Text = assistenciaModel.Contato;
                empresaInput.Text = assistenciaModel.EmpresaSuporte;
                descricaoInput.Text = assistenciaModel.Descriacao;
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
            else if(!Validadores.TextValidator(empresaInput.Text))
            {
                new CreateResponseModal("INSIRA UMA EMPRESA SUPORTE VÁLIDA!").Show();
                formValido = false;
            }
            else if (!Validadores.TelefoneValidator(telefoneInput.Text))
            {
                new CreateResponseModal("INSIRA UM TELEFONE VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.ComboxValidator(planoDropdown))
            {
                new CreateResponseModal("INSIRA UM PLANO VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.MuilLineValidator(descricaoInput.Text))
            {
                new CreateResponseModal("INSIRA UMA DESCRIÇÃO DE 0 A 200 LETRAS VÁLIDA!").Show();
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
                empresaInput.Enabled = false;
                planoDropdown.Enabled = false;
               
            }
            else if (this.FormularioStatus == FormularioStatus.Cadastro)
            {
                idBox.Enabled = false;
                searchById.Visible = false;
                nameInput.Enabled = true;
                empresaInput.Enabled = true;
                planoDropdown.Enabled = true;
            }
        }

        private void Clear()
        {
            idBox.Text = "";
            nameInput.Text = "";
            telefoneInput.Text = "";
            planoDropdown.SelectedIndex = -1;
            empresaInput.Text = "";
            descricaoInput.Text = "";
        }

        private async void InitFormulario()
        {
            var listTemp = await planoRepository.GetAllPlanos();
            listTemp.ForEach((e) => planoListModels.Add(new PlanoListModel(e.Id, e.NomePlano)));
            this.FormularioStatus = FormularioStatus.Cadastro;
            GetList();
            foreach (var item in planoListModels)
            {
                planoDropdown.Items.Add(item.Name);
            }
            planoDropdown.SelectedIndex = -1;
            assistList.Font = new Font("Segoe UI", 12);
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
                var lst = await assistenciaRepository.GetAllAssistencias();
                if (lst.Count == 0)
                    assistList.Controls.Add(myGrid);
                else
                    assistList.DataSource = lst;
            }
            catch (Exception e)
            {
                new CreateResponseModal("ERRO: \n" + e.Message).Show();
            }
        }
        

        #region ViewsNA
        private void label3_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void CrudAssistencia_Load(object sender, EventArgs e)
        {

        }
    }
}

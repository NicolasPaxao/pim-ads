using NPOI.SS.Formula.Functions;
using pim_desktop.Components;
using pim_desktop.Constants;
using pim_desktop.Enums;
using pim_desktop.Model;
using pim_desktop.Repository.ClienteRepository;
using pim_desktop.Repository.FuncionarioRepository;
using pim_desktop.Views.Modals;
using pim_desktop.Views.Partials;
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
    public partial class CrudCliente : Form
    {
        public FormularioTipoCliente FormularioTipoCliente { get; set; }
        public ClienteModel clienteModel = new ClienteModel();
        public ClienteRepository clienteRepository = new ClienteRepository();

        private Form activeForm = null;

        public CrudCliente()
        {
           
            InitializeComponent();
            InitFormulario();
            
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(childForm);
            panelPrincipal.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void switchFormularioCrud_CheckedChanged(object sender, EventArgs e)
        {
            if (!switchFormularioCrud.Checked)
            {
                this.FormularioTipoCliente = FormularioTipoCliente.PF;
                openChildForm(new FormClientePf());
                labelFormulario.Text = "Cadastro de Cliente PF";
                GetList();
            }
            else
            {
                this.FormularioTipoCliente = FormularioTipoCliente.PJ;
                openChildForm(new FormClientePj());
                labelFormulario.Text = "Cadastro de Cliente PJ";
                GetList();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            new DeleteModal(clienteRepository.DeletarCliente).Show();
            GetList();

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Consts.changeStatus = FormularioStatus.Atualizacao;
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void InitFormulario()
        {
            Consts.changeStatus = FormularioStatus.Cadastro;
            switchFormularioCrud.Checked = false;
            openChildForm(new FormClientePf());
            GetList();
            clienteList.Font = new Font("Segoe UI", 10);
        }

        private async void GetList()
        {
            var myGrid = new DataGridCustom();
            myGrid.EmptyResultText = "SEM DADOS PARA MOSTRAR";
            myGrid.Dock = DockStyle.Fill;
            myGrid.DataSource = new List<string>();
            try
            {
                var lstPj = await clienteRepository.GetAllClientesPj();
                var lstPf = await clienteRepository.GetAllClientesPf();
                if (!switchFormularioCrud.Checked)
                {
                    if (lstPf.Count == 0)
                        clienteList.Controls.Add(myGrid);
                    else
                        clienteList.DataSource = lstPf;
                }
                else
                {
                    if (lstPj.Count == 0)
                        clienteList.Controls.Add(myGrid);
                    else
                        clienteList.DataSource = lstPj;
                }
            }
            catch (Exception e)
            {
                new CreateResponseModal("ERRO: \n" + e.Message).Show();
            }
        }

        private void CrudCliente_Load(object sender, EventArgs e)
        {

        }
    }
}

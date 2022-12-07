using pim_desktop.Views.Comercial;
using pim_desktop.Views.Modals;
using pim_desktop.Views.RecursosHumanos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pim_desktop.Views
{
    public partial class BaseLayout : Form
    {
        private Form activeForm = null;
        private InfoMenu infoMenu = new InfoMenu();

        public BaseLayout()
        {
            InitializeComponent();
            CustomizeDesing();
        }
        private void CustomizeDesing()
        {
            panelRh.Visible = false;
            panelComercial.Visible = false;
            panelVendas.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panelRh.Visible == true)
                panelRh.Visible = false;
            if (panelComercial.Visible == true)
                panelComercial.Visible = false;
            if (panelVendas.Visible == true)
                panelVendas.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnRh_Click(object sender, EventArgs e)
        {
            showSubMenu(panelRh);
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            openChildForm(new CrudFuncionarioView());
        }

        private void btnComercial_Click(object sender, EventArgs e)
        {
            showSubMenu(panelComercial);
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelVendas);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAssistencia_Click(object sender, EventArgs e)
        {
            openChildForm(new CrudAssistencia());
        }

        private void btnCobertura_Click(object sender, EventArgs e)
        {
            openChildForm(new CrudCobertura());
        }

        private void btnSeguradora_Click(object sender, EventArgs e)
        {
            openChildForm(new CrudSeguradora());
        }

        private void btnSuporte_Click(object sender, EventArgs e)
        {
            openChildForm(new SuporteAoUsuario());
        }

        private void btnDesempenho_Click(object sender, EventArgs e)
        {
            openChildForm(new DesempenhoDoFuncionario());
        }

        private void btnPlanos_Click(object sender, EventArgs e)
        {
            openChildForm(new CrudPlano());
        }

        private void btnDesemComercial_Click(object sender, EventArgs e)
        {
            openChildForm(new DesempenhoComercial());
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            openChildForm(new CrudCliente());
        }

        private void btnAutomovel_Click(object sender, EventArgs e)
        {
            openChildForm(new CrudAutomovel());
        }

        private void btnRealizarVenda_Click(object sender, EventArgs e)
        {
            openChildForm(new RealizarVenda());
        }

        private void btnGerarApolice_Click(object sender, EventArgs e)
        {
            openChildForm(new GerarApolice());
        }
        bool visible = false;
        private void openInformDialog_Click(object sender, EventArgs e)
        {
            
            visible = !visible;
            if (visible == true)
            {
                infoMenu.StartPosition = FormStartPosition.Manual;
                var topLeft = openInformDialog.PointToScreen(new Point(0, 0));
                infoMenu.Location = new Point(topLeft.X - 230, topLeft.Y + openInformDialog.Height);
                infoMenu.Visible = true;
            }
            else
            {
                infoMenu.Visible = false;
            }
            
        }

        private void infoPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

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
    public partial class AuthView : Form
    {
        Form baseView = new BaseLayout();
        string emailAdm = "adm@tsbseguros.com";
        string senhaAdm = "tsb123@";
        public AuthView()
        {
            InitializeComponent();
            emailInput.Text = emailAdm;
            senhaInput.Text = senhaAdm;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (emailInput.Text == emailAdm && senhaInput.Text == senhaAdm)
            {
                this.Hide();
                baseView.Closed += (s, args) => this.Close();
                baseView.Show();
            }
            else
            {
                new CreateResponseModal("LOGIN NÃO AUTORIZADO!").Show();
            }
        }
    }
}

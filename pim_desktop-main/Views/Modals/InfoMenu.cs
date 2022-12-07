using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pim_desktop.Views.Modals
{
    public partial class InfoMenu : Form
    {
        

        public InfoMenu()
        {
            InitializeComponent();
        }

        private void InfoMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

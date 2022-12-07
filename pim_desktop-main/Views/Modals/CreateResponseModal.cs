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
    public partial class CreateResponseModal : Form
    {
        public CreateResponseModal(string title)
        {
            InitializeComponent();
            titleResponse.Text = title;
        }

        private void titleResponse_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

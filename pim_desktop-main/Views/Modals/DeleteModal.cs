using NPOI.SS.Formula.Functions;
using pim_desktop.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pim_desktop.Views.Modals
{
    public partial class DeleteModal : Form
    {
        
  
        public Action<int> funcaoDeletar { get; set; }
        public DeleteModal(Action<int> funcaoDeletar)
        {
            InitializeComponent();
            this.funcaoDeletar = funcaoDeletar;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validadores.NumberValidator(idInput.Text))
                funcaoDeletar(int.Parse(idInput.Text));
            else
                new CreateResponseModal("INSIRA UM ID VÁLIDO").Show();
            this.Close();
        }

        private void DeleteModal_Load(object sender, EventArgs e)
        {

        }

        private void idInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

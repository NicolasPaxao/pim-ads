using pim_desktop.Repository.ApoliceRepository;
using pim_desktop.Repository.RelatoriosRepository;
using pim_desktop.Views.Modals;
using pim_desktop.Views.Relatorios;
using pim_desktop.Views.Relatorios.DesempenhoFuncionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pim_desktop.Views.RecursosHumanos
{
    public partial class DesempenhoDoFuncionario : Form
    {
        RelatoriosRepository relatoriosRepository = new RelatoriosRepository();
        public DesempenhoDoFuncionario()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private async void imprimirBtn_Click(object sender, EventArgs e)
        {
            string mes = mesInput.Text;
            string ano = anoInput.Text;
            var rela = await relatoriosRepository.GetDesempenhoFunc((ano + mes).ToString(), int.Parse(indInput.Text));
            if (rela != null && rela.Count != 0)
            {
                using (var frm = new DesemFunReport(rela))
                    frm.ShowDialog();
            }
        }
    }
}

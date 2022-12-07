using pim_desktop.Repository.RelatoriosRepository;
using pim_desktop.Views.Modals;
using pim_desktop.Views.Relatorios.DesempenhoEmpresa;
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

namespace pim_desktop.Views
{
    public partial class DesempenhoComercial : Form
    {
        RelatoriosRepository relatoriosRepository = new RelatoriosRepository();
        public DesempenhoComercial()
        {
            InitializeComponent();
        }

        private async void imprimirBtn_Click(object sender, EventArgs e)
        {
            string mes = mesInput.Text;
            string ano = anoInput.Text;
            var rela = await relatoriosRepository.GetDesempenhoEmp((ano + mes).ToString());

            if (rela != null && rela.Count != 0)
            {
                using (var frm = new DesemEmpReport(rela))
                    frm.ShowDialog();
            }
        }
    }
}

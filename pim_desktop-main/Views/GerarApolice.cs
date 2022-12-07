using pim_desktop.Repository.ApoliceRepository;
using pim_desktop.Views.Modals;
using pim_desktop.Views.Relatorios;
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
    public partial class GerarApolice : Form
    {
        ApoliceRepository apoliceRepository = new ApoliceRepository();
        public GerarApolice()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button9_Click(object sender, EventArgs e)
        {
            var apolice = await apoliceRepository.GetApoliceByCarId(int.Parse(idText.Text));
            if (apolice.ClienteNome != null || apolice.Automovel != null)
                using (var frm = new ApoliceReport(apolice))
                    frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GerarApolice_Load(object sender, EventArgs e)
        {

        }
    }
}

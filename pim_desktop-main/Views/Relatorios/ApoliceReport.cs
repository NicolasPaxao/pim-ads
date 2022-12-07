using pim_desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pim_desktop.Views.Relatorios
{
    public partial class ApoliceReport : Form
    {
        
        public ApoliceReport(GenerateApolice apolice)
        {
            InitializeComponent();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "pim_desktop.Views.Relatorios.ApoliceRelatorio.rdlc";
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[14];
            var data = apolice.DataCriacao;
            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente", apolice.ClienteNome);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("Modelo", apolice.Automovel.Modelo);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("Marca", apolice.Automovel.Marca);
            p[3] = new Microsoft.Reporting.WinForms.ReportParameter("Ano_Modelo", apolice.Automovel.AnoModelo);
            p[4] = new Microsoft.Reporting.WinForms.ReportParameter("Placa", apolice.Automovel.Placa);
            p[5] = new Microsoft.Reporting.WinForms.ReportParameter("Cor", apolice.Automovel.Cor) ;
            p[6] = new Microsoft.Reporting.WinForms.ReportParameter("Renavam", apolice.Automovel.Renavam);
            p[7] = new Microsoft.Reporting.WinForms.ReportParameter("Numero_Motor", apolice.Automovel.NumeroMotor);
            p[8] = new Microsoft.Reporting.WinForms.ReportParameter("Crlv", apolice.Automovel.Crlv);
            p[9] = new Microsoft.Reporting.WinForms.ReportParameter("Plano_Nome", apolice.PlanoNome);
            p[10] = new Microsoft.Reporting.WinForms.ReportParameter("Plano_Valor", apolice.PlanoValor.ToString());
            p[11] = new Microsoft.Reporting.WinForms.ReportParameter("TempoVigencia", apolice.TempoVigencia.ToString());
            p[12] = new Microsoft.Reporting.WinForms.ReportParameter("Forma_Pagamento", apolice.FormaPagamento.Value.ToString());
            p[13] = new Microsoft.Reporting.WinForms.ReportParameter("DataCriacao", data.ToString("d", new CultureInfo("pt-BR"))) ;


            reportViewer1.LocalReport.SetParameters(p);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();

        }

        private void ApoliceReport_Load(object sender, EventArgs e)
        {

        }
    }
}

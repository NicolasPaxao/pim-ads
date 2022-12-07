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

namespace pim_desktop.Views.Relatorios.DesempenhoEmpresa
{
    public partial class DesemEmpReport : Form
    {
        public List<DesempenhoEmpModel> Lst { get; set; }
        public DesemEmpReport(List<DesempenhoEmpModel> lst)
        {
            InitializeComponent();
            Lst = lst;
        }

        private void DesemEmpReport_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[3];
            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("Mes", Lst[0].DataCriacao.Month.ToString());
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("Ano", Lst[0].DataCriacao.Year.ToString());
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("QtVendas", Lst.Count.ToString());

            var datatable = new DataTable();
            datatable.Columns.Add("IdApolice", typeof(int));
            datatable.Columns.Add("Valor", typeof(decimal));
            datatable.Columns.Add("DataCriacao", typeof(string));

            Lst.ForEach((e) => datatable.Rows.Add(e.IdApolice, e.ValorPlano, e.DataCriacao.ToString("d", new CultureInfo("pt-BR"))));
           
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "pim_desktop.Views.Relatorios.DesempenhoEmpresa.DesemEmpRelatorio.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", datatable));
            this.reportViewer1.LocalReport.SetParameters(p);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}

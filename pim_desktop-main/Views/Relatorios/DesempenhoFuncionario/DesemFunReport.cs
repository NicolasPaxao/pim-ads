using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
using DataSet = System.Data.DataSet;

namespace pim_desktop.Views.Relatorios.DesempenhoFuncionario
{
    public partial class DesemFunReport : Form
    {
        public List<DesempenhoFuncModel> Lst { get; set; }
        public DesemFunReport(List<DesempenhoFuncModel> lst)
        {
            InitializeComponent();
            Lst = lst;
        }

        private void DesemFunReport_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[4];
            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("Funcionario", Lst[0].FuncionarioNome);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("Mes", Lst[0].DataCriacao.Month.ToString());
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("Ano", Lst[0].DataCriacao.Year.ToString());
            p[3] = new Microsoft.Reporting.WinForms.ReportParameter("QtVendas", Lst.Count.ToString());
            

            var datatable = new DataTable();
            datatable.Columns.Add("IdApolice", typeof(int));
            datatable.Columns.Add("Valor", typeof(decimal));
            datatable.Columns.Add("NomeFuncionario", typeof(string));
            datatable.Columns.Add("DataCriacao", typeof(string));
          
            Lst.ForEach((e)=> datatable.Rows.Add(e.IdApolice, e.ValorPlano, e.FuncionarioNome, e.DataCriacao.ToString("d", new CultureInfo("pt-BR")))) ;
            
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "pim_desktop.Views.Relatorios.DesempenhoFuncionario.DesemFuncRelatorio.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", datatable));
            this.reportViewer1.LocalReport.SetParameters(p);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}

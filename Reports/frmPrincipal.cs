using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using Reports.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reports
{
    public partial class frmPrincipal : Form
    {
        // Reporte que se muestra en el visor
        private TReport Reporte;

        // Formulario Buscar los reportes
        private frmBuscarReportes oListaReportes;


        public frmPrincipal()
        {
            InitializeComponent();
            oListaReportes = new frmBuscarReportes();
            Reporte = null;
        }

        // Muestra el reporte
        private void ShowReport(ReportClass reporte ) {
            var param= reporte.ParameterFields;
            foreach (ParameterField p in param) { 
                if(p.Name == "FechaIni") reporte.SetParameterValue("FechaIni", fechaInicial.Value.ToString("dd/MM/yyyy"));
                if(p.Name == "FechaFin") reporte.SetParameterValue("FechaFin", fechaFinal.Value.ToString("dd/MM/yyyy"));
                if(p.Name == "NoDocumento") reporte.SetParameterValue("NoDocumento", txtNoDocumento.Text);
            }
            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.Zoom(100);
            crystalReportViewer1.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            oListaReportes.ShowDialog();
            Reporte = oListaReportes.Reporte;
            if (Reporte != null){
                txtCodReport.Text = Reporte.Codigo;
                txtDescReport.Text = Reporte.Descripcion;
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowReport(Reporte.Reporte);
        }
    }
}

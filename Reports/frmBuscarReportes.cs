using Reports.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reports
{
    public partial class frmBuscarReportes : Form
    {
        DataView ViewData;

        public TReport Reporte;
        private ReportList Reportes;
        private DataTable dtReportes;

        public frmBuscarReportes(object data =null)
        {
            InitializeComponent();
            Reportes = new ReportList();
            Reporte = null;
        }

        // Carga los datos de los reportes en los controles 
        private void LoadData() {

            dtReportes = new DataTable();
            dtReportes.Columns.Add("Codigo", typeof(string));
            dtReportes.Columns.Add("Descripcion", typeof(string));
            foreach (var item in Reportes.GetListReports())
            {
                DataRow row = dtReportes.NewRow();
                row["Codigo"] = item.Key;
                row["Descripcion"] = item.Value;
                dtReportes.Rows.Add(row);
            }
            ViewData = new DataView(dtReportes);
            G1.DataSource = ViewData;
        }

        //devolvemos el codigo seleccionado por el usuario
        public void GetCodigo() {
                  
            if (G1.Rows.Count > 0)
            {
                String Codigo = G1.CurrentRow.Cells[0].Value.ToString();
                String Descripcion = G1.CurrentRow.Cells[1].Value.ToString();
                Reporte =  Reportes.getReport(Codigo);
            }
            this.Close();
        }
                        

        private void frmBuscador_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.GetCodigo();
        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(13))
            {
                this.GetCodigo();
            }
        }

        private void dtg1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.GetCodigo();
        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            ViewData.RowFilter = "Descripcion  LIKE  '%" + txtFiltrar.Text.ToString() + "%' OR Codigo LIKE '%" + txtFiltrar.Text.ToString() + "%' ";
        }
    }
}

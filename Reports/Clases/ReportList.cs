using CrystalDecisions.CrystalReports.Engine;
using Reports.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Clases
{
    public class ReportList
    {
        private  List<TReport> lstReports = new List<TReport>();

        public ReportList() {

            lstReports.Add(new TReport
            {
                Codigo = "R-01",
                Descripcion = "Reporte de Prueba No. 01 - Parametrizado con Rango de fechas y No. Documento",
                Reporte = new TestReport1()
            }) ;

            lstReports.Add(new TReport
            {
                Codigo = "R-02",  Descripcion = "Reporte de Prueba No. 02 - Parametrizado con No. Documento",
                Reporte = new TestReport2()
            });
        }

        public Dictionary<String, String>  GetListReports() {
            return lstReports.ToDictionary(r => r.Codigo, r => r.Descripcion);
        }

        public TReport getReport(String codigo) {
            return lstReports.FirstOrDefault(r => r.Codigo == codigo);
        }
    }
}

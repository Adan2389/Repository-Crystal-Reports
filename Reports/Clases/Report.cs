using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Clases
{
    public class TReport
    {
        public String Codigo { get; set; }
        public String Descripcion { get; set; }
        public ReportClass Reporte { get; set; }
    }
}

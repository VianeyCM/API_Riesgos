using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ReporteMDCambios
    {
        public int Fecha { get; set; }
        public int Cve_contraparte { get; set; }
        public string Descripcion { get; set; }
        public int Tipo_oper { get; set; }
        public string Posicion { get; set; }
        public long Monto { get; set; }
        public string Tipo_moneda { get; set; }
        public int Cve_moneda { get; set; }
        public decimal Tipo_cambio_conc { get; set; }
        public decimal Tipo_cambio_mdo { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ResultadoAPI
    {
        public string? mensaje { get; set; }
        public List<ValuacionReportos>? listaValuacionReportos { get; set; }
        public List<TenenciaTitulos>? listaTenenciaTitulos { get; set; }
        public List<ComprasMesaDinero>? listaComprasMesaDinero { get; set; }
        public List<ComprasTesoreria>? listaComprasTesoreria { get; set; }
        public List<PosicionPatrimonial>? listaPosicionPatrimonial { get; set; }
        public List<ReporteREVAME>? listaReporteREVAME { get; set; }
        public List<PosicionCalculoVAR>? listaPosicionCalculoVAR { get; set; }
        public List<PosicionRegulatorios>? listaPosicionRegulatorios { get; set; }
        public List<ReportePosicionTesoreria>? listaReportePosicionTesoreria { get; set; }
        public List<PosicionGlobalTitulos>? listaPosicionGlobalTitulos { get; set; }
        public List<MovimientosTesoreria>? listaMovimientosTesoreria { get; set; }
        public List<ComprasVentasOperador>? listaComprasVentasOperador { get; set; }
        public List<ReporteMDCambios>? listaReporteMDCambios { get; set; }
    }
}

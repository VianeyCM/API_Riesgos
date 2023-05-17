﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class PosicionRegulatorios
    {
        public int Fecha { get; set; }
        public string Emision { get; set; }
        public string TV { get; set; }
        public string Serie { get; set; }
        public string Emisor { get; set; }
        public string Op { get; set; }
        public string TipoInventario { get; set; }
        public int FechaValor { get; set; }
        public int FechaFOper { get; set; }
        //public int FechaVto { get; set; }
        public long NumOper { get; set; }
        public string CompraVenta { get; set; }
        public long Titulos { get; set; }
        public decimal PrecioLibros { get; set; }
        public decimal ImporteLibros { get; set; }
        public long ValorLib { get; set; }
        public int DiasTrans { get; set; }
        public int DxV { get; set; }
        public decimal TasaVto { get; set; }
        public decimal ImporteVto { get; set; }
        public decimal TasaCurva { get; set; }
        public decimal PremioDev { get; set; }
        public decimal TasaMercado { get; set; }
        public decimal VPPV { get; set; }
        //public decimal ImporteAcum { get; set; }
        public decimal PrecioMercado { get; set; }
        public decimal ValorMercado { get; set; }
        //public decimal ImporteMercado { get; set; }
        public int PlazoPapel { get; set; }
        public decimal TvmtoPapel { get; set; }
        //public decimal TasaVtoPos { get; set; }
        public decimal Interes { get; set; }
        public string Area { get; set; }
        public decimal TasaDiaria { get; set; }
        public string ClaveEmisor { get; set; }
        //public string ClaveInstrumento { get; set; }
        public int TInst { get; set; }
        public string Sector { get; set; }
        public int DxVCorte { get; set; }
        public string TipoOper { get; set; }
        public int ClaveContraparte { get; set; }
        public int DxVPapel { get; set; }
        public decimal Duracion { get; set; }
        public string PlazoOper { get; set; }
        public decimal VaDro { get; set; }
        public int SobreTasa { get; set; }

    }
}

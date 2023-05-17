using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DAO
{
    public class DAORiesgos
    {
        private const string Value = "FechaValor";

        public Respuesta guardarValuacionReportos(List<ValuacionReportos> reporte, OracleConnection conexion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;

            }

            borro = eliminarValuacionReportos(reporte[0].FechaValuacion, conexion);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                if (borro)
                {
                    conexion.Open();
                    int aff = 0;
                    foreach (ValuacionReportos item in reporte)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("FECHAVALUACION", item.FechaValuacion);
                        cmd.Parameters.Add("EMISION", item.Emision);
                        cmd.Parameters.Add("TIPO", item.Tipo);
                        cmd.Parameters.Add("FECHA", item.Fecha);
                        cmd.Parameters.Add("NUMCONTRATO", item.NumContrato);
                        cmd.Parameters.Add("NUMREFERENCIA", item.NumReferencia);
                        cmd.Parameters.Add("MOVIMIENTOOPER", item.MovimientoOper);
                        cmd.Parameters.Add("PARTE", item.Parte);
                        cmd.Parameters.Add("TITULOS", item.Titulos);
                        cmd.Parameters.Add("PRECIOOPERACION", item.PrecioOperacion);
                        cmd.Parameters.Add("IMPORTEOPERACION", item.ImporteOperacion);
                        cmd.Parameters.Add("IMPORTELIBROS", item.ImporteLibros);
                        cmd.Parameters.Add("DIASTRANSCURRIDOS", item.DiasTranscurridos);
                        cmd.Parameters.Add("DXV", item.DxV);
                        cmd.Parameters.Add("TASAVENCIMIENTO", item.TasaVencimiento);
                        cmd.Parameters.Add("TASADIARIA", item.TasaDiaria);
                        cmd.Parameters.Add("TASACURVA", item.TasaCurva);
                        cmd.Parameters.Add("PREMIO", item.Premio);
                        cmd.Parameters.Add("PRECIOVECTOR", item.PrecioVector);
                        cmd.Parameters.Add("VALORMERCADO", item.ValorMercado);
                        cmd.Parameters.Add("PORTAFOLIO", item.Portafolio);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESVARM.IKOS_VAL_REPORTOS (FECHAVALUACION" +
                                                                                 ",EMISION" +
                                                                                 ",TIPO" +
                                                                                 ",FECHA" +
                                                                                 ",NUMCONTRATO" +
                                                                                 ",NUMREFERENCIA" +
                                                                                 ",MOVIMIENTOOPER" +
                                                                                 ",PARTE" +
                                                                                 ",TITULOS" +
                                                                                 ",PRECIOOPERACION" +
                                                                                 ",IMPORTEOPERACION" +
                                                                                 ",IMPORTELIBROS" +
                                                                                 ",DIASTRANSCURRIDOS" +
                                                                                 ",DXV" +
                                                                                 ",TASAVENCIMIENTO" +
                                                                                 ",TASADIARIA" +
                                                                                 ",TASACURVA" +
                                                                                 ",PREMIO" +
                                                                                 ",PRECIOVECTOR" +
                                                                                 ",VALORMERCADO" +
                                                                                 ",PORTAFOLIO) " +
                                                                          "VALUES (:FECHAVALUACION, :EMISION, :TIPO, :FECHA, :NUMCONTRATO, :NUMREFERENCIA, :MOVIMIENTOOPER, :PARTE, :TITULOS, :PRECIOOPERACION, :IMPORTEOPERACION, :IMPORTELIBROS, :DIASTRANSCURRIDOS," +
                                                                                  ":DXV, :TASAVENCIMIENTO, :TASADIARIA, :TASACURVA, :PREMIO, :PRECIOVECTOR, :VALORMERCADO, :PORTAFOLIO)";

                        cmd.CommandType = CommandType.Text;
                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje += "Hubo un error al borrar los registros. " + conexion.ConnectionString.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
        public Respuesta guardarTenenciaTitulos(List<TenenciaTitulos> reporte, OracleConnection conexion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;

            }

            borro = eliminarTenenciaTitulos(reporte[0].FechaValuacion, conexion);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                if (borro)
                {
                    conexion.Open();
                    int aff = 0;
                    foreach (TenenciaTitulos item in reporte)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("FECHAVALUACION", item.FechaValuacion);
                        cmd.Parameters.Add("EMISION", item.Emision);
                        cmd.Parameters.Add("TITULOS", item.Titulos);
                        cmd.Parameters.Add("ImporteSucio", item.ImporteSucio);
                        cmd.Parameters.Add("TIPO", item.Tipo);
                        cmd.Parameters.Add("Descripcion", item.Descripcion);
                        cmd.Parameters.Add("PORTAFOLIO", item.Portafolio);
                        cmd.Parameters.Add("NumOperacion", item.NumOperacion);
                        cmd.Parameters.Add("InteresDevengado", item.InteresDevengado);
                        cmd.Parameters.Add("TitulosGarantia", item.TitulosGarantia);
                        cmd.Parameters.Add("Intercupon", item.Intercupon);
                        cmd.Parameters.Add("DXVencer", item.DXVencer);
                        cmd.Parameters.Add("DXVRC0103", item.DXVRC0103);
                        cmd.Parameters.Add("PrecioSucio", item.PrecioSucio);
                        cmd.Parameters.Add("PrecioLimpio", item.PrecioLimpio);
                        cmd.Parameters.Add("ImporteLimpio", item.ImporteLimpio);
                        cmd.Parameters.Add("ImporteInteres", item.ImporteInteres);
                        cmd.Parameters.Add("PrecioMercado", item.PrecioMercado);
                        cmd.Parameters.Add("ImporteMercado", item.ImporteMercado);
                        cmd.Parameters.Add("DXVRC02", item.DXVRC02);
                        cmd.Parameters.Add("PlusMinus", item.PlusMinus);
                        cmd.Parameters.Add("TasaCosto", item.TasaCosto);
                        cmd.Parameters.Add("Parte", item.Parte);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESVARM.IKOS_TENENCIA_TITULOS (FECHAVALUACION" +
                                                                                                   ",EMISION" +
                                                                                                   ",TITULOS" +
                                                                                                   ",ImporteSucio" +
                                                                                                   ",TIPO" +
                                                                                                   ",Descripcion" +
                                                                                                   ",PORTAFOLIO" +
                                                                                                   ",NumOperacion" +
                                                                                                   ",InteresDevengado" +
                                                                                                   ",TitulosGarantia" +
                                                                                                   ",Intercupon" +
                                                                                                   ",DXVencer" +
                                                                                                   ",DXVRC0103" +
                                                                                                   ",PrecioSucio" +
                                                                                                   ",PrecioLimpio" +
                                                                                                   ",ImporteLimpio" +
                                                                                                   ",ImporteInteres" +
                                                                                                   ",PrecioMercado" +
                                                                                                   ",ImporteMercado" +
                                                                                                   ",DXVRC02" +
                                                                                                   ",PlusMinus" +
                                                                                                   ",TasaCosto" +
                                                                                                   ",Parte) " +
                                                                                            "VALUES (:FECHAVALUACION,:EMISION,:TITULOS,:ImporteSucio,:TIPO,:Descripcion,:PORTAFOLIO,:NumOperacion,:InteresDevengado,:TitulosGarantia,:Intercupon,:DXVencer,:DXVRC0103,:PrecioSucio,:PrecioLimpio,:ImporteLimpio,:ImporteInteres,:PrecioMercado,:ImporteMercado,:DXVRC02,:PlusMinus,:TasaCosto,:Parte)";

                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
        public Respuesta guardarComprasMesaDinero(List<ComprasMesaDinero> reporte, OracleConnection conexion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;

            }

            borro = eliminarComprasMesaDinero(Convert.ToInt32(reporte[0].FechaValor), conexion);

            conexion.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;


            try
            {
                if (borro)
                {
                    //conexion.Open();
                    int aff = 0;
                    foreach (ComprasMesaDinero item in reporte)
                    {

                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("FechaValor", item.FechaValor);
                        cmd.Parameters.Add("Moneda", item.Moneda);
                        cmd.Parameters.Add("NumOperacion", item.NumOperacion);
                        cmd.Parameters.Add("Contraparte", item.Contraparte);
                        cmd.Parameters.Add("Papel", item.Papel);
                        cmd.Parameters.Add("Emision", item.Emision);
                        cmd.Parameters.Add("Posicion", item.Posicion);
                        cmd.Parameters.Add("FV", item.FV);
                        cmd.Parameters.Add("NumTitulos", item.NumTitulos);
                        cmd.Parameters.Add("PrecioSucio", item.PrecioSucio);
                        cmd.Parameters.Add("TasaRend", item.TasaRend);
                        cmd.Parameters.Add("TasaDiaria", item.TasaDiaria);
                        cmd.Parameters.Add("Plazo", item.Plazo);
                        cmd.Parameters.Add("ImporteReal", item.ImporteReal);
                        cmd.Parameters.Add("Portafolio", item.Portafolio);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESVARM.IKOS_COMPRAS_MD (FechaValor" +
                                                                                            ",Moneda" +
                                                                                            ",NumOperacion" +
                                                                                            ",Contraparte" +
                                                                                            ",Papel" +
                                                                                            ",Emision" +
                                                                                            ",Posicion" +
                                                                                            ",FV" +
                                                                                            ",NumTitulos" +
                                                                                            ",PrecioSucio" +
                                                                                            ",TasaRend" +
                                                                                            ",TasaDiaria" +
                                                                                            ",Plazo" +
                                                                                            ",ImporteReal" +
                                                                                            ",PORTAFOLIO) " +
                                                                                            "VALUES (:FechaValor,:Moneda,:NumOperacion,:Contraparte,:Papel,:Emision,:Posicion,:FV,:NumTitulos,:PrecioSucio,:TasaRend,:TasaDiaria,:Plazo,:ImporteReal,:Portafolio)";
                        cmd.CommandType = CommandType.Text;
                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
        public Respuesta guardarComprasTesoreria(List<ComprasTesoreria> reporte, OracleConnection conexion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;

            }

            borro = eliminarComprasTesoreria(Convert.ToInt32(reporte[0].FechaValor), conexion);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                if (borro)
                {
                    conexion.Open();
                    int aff = 0;
                    foreach (ComprasTesoreria item in reporte)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("FechaValor", item.FechaValor);
                        cmd.Parameters.Add("Moneda", item.Moneda);
                        cmd.Parameters.Add("NumOperacion", item.NumOperacion);
                        cmd.Parameters.Add("Contraparte", item.Contraparte);
                        cmd.Parameters.Add("Papel", item.Papel);
                        cmd.Parameters.Add("Emision", item.Emision);
                        cmd.Parameters.Add("Posicion", item.Posicion);
                        cmd.Parameters.Add("FV", item.FV);
                        cmd.Parameters.Add("NumTitulos", item.NumTitulos);
                        cmd.Parameters.Add("PrecioSucio", item.PrecioSucio);
                        cmd.Parameters.Add("TasaRend", item.TasaRend);
                        cmd.Parameters.Add("TasaDiaria", item.TasaDiaria);
                        cmd.Parameters.Add("Plazo", item.Plazo);
                        cmd.Parameters.Add("ImporteReal", item.ImporteReal);
                        cmd.Parameters.Add("Portafolio", item.Portafolio);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESVARM.IKOS_COMPRAS_TESO (FechaValor" +
                                                                                               ",Moneda" +
                                                                                               ",NumOperacion" +
                                                                                               ",Contraparte" +
                                                                                               ",Papel" +
                                                                                               ",Emision" +
                                                                                               ",Posicion" +
                                                                                               ",FV" +
                                                                                               ",NumTitulos" +
                                                                                               ",PrecioSucio" +
                                                                                               ",TasaRend" +
                                                                                               ",TasaDiaria" +
                                                                                               ",Plazo" +
                                                                                               ",ImporteReal" +
                                                                                               ",PORTAFOLIO) " +
                                                                                        "VALUES (:FechaValor,:Moneda,:NumOperacion,:Contraparte,:Papel,:Emision,:Posicion,:FV,:NumTitulos,:PrecioSucio,:TasaRend,:TasaDiaria,:Plazo,:ImporteReal,:Portafolio)";
                        cmd.CommandType = CommandType.Text;
                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
        public Respuesta guardarPosicionPatrimonial(List<PosicionPatrimonial> reporte, OracleConnection conexion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;
            }

            borro = eliminarPosicionPatrimonial(Convert.ToInt32(reporte[0].FechaValuacion), conexion);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                if (borro)
                {
                    conexion.Open();
                    int aff = 0;
                    foreach (PosicionPatrimonial item in reporte)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("FechaValuacion", item.FechaValuacion);
                        cmd.Parameters.Add("FechaInicioOper", item.FechaInicioOper);
                        cmd.Parameters.Add("NumOpera", item.NumOpera);
                        cmd.Parameters.Add("Cliente", item.Cliente);
                        cmd.Parameters.Add("TipoInstrumento", item.TipoInstrumento);
                        cmd.Parameters.Add("NumTitulosPos", item.NumTitulosPos);
                        cmd.Parameters.Add("Monto", item.Monto);
                        cmd.Parameters.Add("Plazo", item.Plazo);
                        cmd.Parameters.Add("DT", item.DT);
                        cmd.Parameters.Add("DXV", item.DXV);
                        cmd.Parameters.Add("Tasa", item.Tasa);
                        cmd.Parameters.Add("PremioDev", item.PremioDev);
                        cmd.Parameters.Add("ImpCIntereses", item.ImpCIntereses);
                        cmd.Parameters.Add("FechaVencimiento", item.FechaVencimiento);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESVARM.IKOS_PATRIMONIAL (FechaValuacion" +
                                                                                              ",FechaInicioOper" +
                                                                                              ",NumOpera" +
                                                                                              ",Cliente" +
                                                                                              ",TipoInstrumento" +
                                                                                              ",NumTitulosPos" +
                                                                                              ",Monto" +
                                                                                              ",Plazo" +
                                                                                              ",DT" +
                                                                                              ",DXV" +
                                                                                              ",Tasa" +
                                                                                              ",PremioDev" +
                                                                                              ",ImpCIntereses" +
                                                                                              ",FechaVencimiento) " +
                                                                                       "VALUES (:FechaValuacion,:FechaInicioOper,:NumOpera,:Cliente,:TipoInstrumento,:NumTitulosPos,:Monto,:Plazo,:DT,:DXV,:Tasa,:PremioDev,:ImpCIntereses,:FechaVencimiento)";

                        cmd.CommandType = CommandType.Text;
                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
        public Respuesta guardarReporteREVAME(List<ReporteREVAME> reporte, OracleConnection conexion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;
            }

            borro = eliminarReporteREVAME(Convert.ToInt32(reporte[0].Fecha), conexion);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                if (borro)
                {
                    conexion.Open();
                    int aff = 0;
                    foreach (ReporteREVAME item in reporte)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("Fecha", item.Fecha);
                        cmd.Parameters.Add("Portafolio", item.Portafolio);
                        cmd.Parameters.Add("Emision", item.Emision);
                        cmd.Parameters.Add("Titulos", item.Titulos);
                        cmd.Parameters.Add("PrecioLimpio", item.PrecioLimpio);
                        cmd.Parameters.Add("PrecioSucio", item.PrecioSucio);
                        cmd.Parameters.Add("ImporteLimpio", item.ImporteLimpio);
                        cmd.Parameters.Add("ImporteSucio", item.ImporteSucio);
                        cmd.Parameters.Add("PrecioLimpioLib", item.PrecioLimpioLib);
                        cmd.Parameters.Add("PrecioSucioLib", item.PrecioSucioLib);
                        cmd.Parameters.Add("ImporteLimpioLib", item.ImporteLimpioLib);
                        cmd.Parameters.Add("ImporteSucioLib", item.ImporteSucioLib);
                        cmd.Parameters.Add("Valuacion", item.Valuacion);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESVARM.IKOS_REVAME (Fecha" +
                                                                            ",Portafolio" +
                                                                            ",Emision" +
                                                                            ",Titulos" +
                                                                            ",PrecioLimpio" +
                                                                            ",PrecioSucio" +
                                                                            ",ImporteLimpio" +
                                                                            ",ImporteSucio" +
                                                                            ",PrecioLimpioLib" +
                                                                            ",PrecioSucioLib" +
                                                                            ",ImporteLimpioLib" +
                                                                            ",ImporteSucioLib" +
                                                                            ",Valuacion) " +
                                                                             "VALUES (:Fecha,:Portafolio,:Emision,:Titulos,:PrecioLimpio,:PrecioSucio,:ImporteLimpio,:ImporteSucio,:PrecioLimpioLib,:PrecioSucioLib,:ImporteLimpioLib,:ImporteSucioLib,:Valuacion)";
                        cmd.CommandType = CommandType.Text;
                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
        public Respuesta guardarPosicionCalculoVAR(List<PosicionCalculoVAR> reporte, OracleConnection conexionRiesgos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;
            }

            borro = eliminarPosicionCalculoVAR(Convert.ToInt32(reporte[0].Fecha), conexionRiesgos);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexionRiesgos;

            try
            {
                if (borro)
                {
                    conexionRiesgos.Open();
                    int aff = 0;
                    foreach (PosicionCalculoVAR item in reporte)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("F_POSICION", item.Fecha);
                        cmd.Parameters.Add("INTENCION", item.Intencion);
                        cmd.Parameters.Add("T_OPERACION", item.TipoOperacion);
                        cmd.Parameters.Add("T_VALOR", item.TipoValor);
                        cmd.Parameters.Add("EMISION", item.Emision);
                        cmd.Parameters.Add("SERIE", item.Serie);
                        cmd.Parameters.Add("F_VENCIMIENTO", item.FechaVto);
                        cmd.Parameters.Add("P_CUPON", item.TCupon);
                        cmd.Parameters.Add("D_VTO", item.D_vto);
                        cmd.Parameters.Add("T_CUPON", item.TasaCupon);
                        cmd.Parameters.Add("T_PREMIO", item.Premio);
                        cmd.Parameters.Add("N_TITULOS", item.Titulos);
                        cmd.Parameters.Add("M_POSICION", item.TipoPosicion);
                        cmd.Parameters.Add("P_COMPRA", item.PrecioCompra);
                        cmd.Parameters.Add("F_COMPRA", item.FechaCompra);
                        cmd.Parameters.Add("MERCADO", item.Mercado);
                        cmd.Parameters.Add("NUMPORTAFOLIO", item.NumPortafolio);
                        cmd.Parameters.Add("NOMPORTAFOLIO", item.Portafolio);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESGO.POS_MESA_TESO (F_POSICION" +
                                                                            ",INTENCION" +
                                                                            ",T_OPERACION" +
                                                                            ",T_VALOR" +
                                                                            ",EMISION" +
                                                                            ",SERIE" +
                                                                            ",F_VENCIMIENTO" +
                                                                            ",P_CUPON" +
                                                                            ",D_VTO" +
                                                                            ",T_CUPON" +
                                                                            ",T_PREMIO" +
                                                                            ",N_TITULOS" +
                                                                            ",M_POSICION" +
                                                                            ",P_COMPRA" +
                                                                            ",F_COMPRA" +
                                                                            ",MERCADO" +
                                                                            ",NUMPORTAFOLIO" +
                                                                            ",NOMPORTAFOLIO) " +
                                                                "VALUES (:F_POSICION,:INTENCION,:T_OPERACION,:T_VALOR,:EMISION,:SERIE,:F_VENCIMIENTO,:P_CUPON,:D_VTO,:T_CUPON,:T_PREMIO,:N_TITULOS,:M_POSICION,:P_COMPRA,:F_COMPRA,:MERCADO,:NUMPORTAFOLIO,:NOMPORTAFOLIO)";
                        cmd.CommandType = CommandType.Text;
                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " resgistros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexionRiesgos.Close();
            }
            return respuesta;
        }
        public Respuesta guardarPosicionRegulatorios(List<PosicionRegulatorios> reporte, OracleConnection conexionRiesgos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;
            }

            borro = eliminarPosicionRegulatorios(Convert.ToInt32(reporte[0].Fecha), conexionRiesgos);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexionRiesgos;

            try
            {
                if (borro)
                {
                    conexionRiesgos.Open();
                    int aff = 0;
                    foreach (PosicionRegulatorios item in reporte)
                    {


                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("FECHA_CORTE", item.Fecha);
                        cmd.Parameters.Add("EMISION", item.Emision);
                        cmd.Parameters.Add("TV", item.TV);
                        cmd.Parameters.Add("SERIE", item.Serie);
                        cmd.Parameters.Add("EMISOR", item.Emisor);
                        cmd.Parameters.Add("OP", item.Op);
                        cmd.Parameters.Add("FECHA_VAL", item.FechaValor);
                        cmd.Parameters.Add("FECHA_F_OPER", item.FechaValor);
                        cmd.Parameters.Add("NUM_OP", item.NumOper);
                        cmd.Parameters.Add("CPRA_VTA", item.CompraVenta);
                        cmd.Parameters.Add("TITULOS", item.Titulos);
                        cmd.Parameters.Add("PRECIO_LIB", item.PrecioLibros);
                        cmd.Parameters.Add("VALOR_LIB", item.ValorLib);
                        cmd.Parameters.Add("DIAS_TRANS", item.DiasTrans);
                        cmd.Parameters.Add("DXV", item.DxV);
                        cmd.Parameters.Add("TASA_VMTO", item.TasaVto);
                        cmd.Parameters.Add("IMP_VMTO", item.ImporteVto);
                        cmd.Parameters.Add("TASA_CVA_P", item.TasaCurva);
                        cmd.Parameters.Add("PREMIO_DEV", item.PremioDev);
                        cmd.Parameters.Add("TASA_MERCA", item.TasaMercado);
                        cmd.Parameters.Add("VPPV", item.VPPV);
                        cmd.Parameters.Add("PRECIO_MERC", item.PrecioMercado);
                        cmd.Parameters.Add("VALOR_MERC", item.ValorMercado);
                        cmd.Parameters.Add("PLAZO_PAPE", item.PlazoPapel);
                        cmd.Parameters.Add("TVMTOPAPEL", item.TvmtoPapel);
                        cmd.Parameters.Add("INTERES_PA", item.Interes);
                        cmd.Parameters.Add("AREA", item.Area);
                        cmd.Parameters.Add("TAS_DIARIA", item.TasaDiaria);
                        cmd.Parameters.Add("CLAVE_EMISOR", '0'); //
                        cmd.Parameters.Add("T_INST", item.TInst);
                        cmd.Parameters.Add("SECTOR", '0');//
                        cmd.Parameters.Add("DXV_FCORTE", item.DxVCorte);
                        cmd.Parameters.Add("T_OPER", item.TipoOper);
                        cmd.Parameters.Add("CVE_CONT", item.ClaveContraparte);
                        cmd.Parameters.Add("DXV_PAPEL", item.DxVPapel);
                        cmd.Parameters.Add("DURACION", item.Duracion);
                        cmd.Parameters.Add("PLAZO_OPER", item.PlazoOper);
                        cmd.Parameters.Add("VA_DRO", item.VaDro);
                        cmd.Parameters.Add("SOBRETASA", item.SobreTasa);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESGO.LIQ_REPORTOS (FECHA_CORTE" +
                                                                                        ",EMISION" +
                                                                                        ",TV" +
                                                                                        ",SERIE" +
                                                                                        ",EMISOR" +
                                                                                        ",OP" +
                                                                                        ",FECHA_VAL" +
                                                                                        ",FECHA_F_OPER" +
                                                                                        ",NUM_OP" +
                                                                                        ",CPRA_VTA" +
                                                                                        ",TITULOS" +
                                                                                        ",PRECIO_LIB" +
                                                                                        ",VALOR_LIB" +
                                                                                        ",DIAS_TRANS" +
                                                                                        ",DXV" +
                                                                                        ",TASA_VMTO" +
                                                                                        ",IMP_VMTO" +
                                                                                        ",TASA_CVA_P" +
                                                                                        ",PREMIO_DEV" +
                                                                                        ",TASA_MERCA" +
                                                                                        ",VPPV" +
                                                                                        ",PRECIO_MERC" +
                                                                                        ",VALOR_MERC" +
                                                                                        ",PLAZO_PAPE" +
                                                                                        ",TVMTOPAPEL" +
                                                                                        ",INTERES_PA" +
                                                                                        ",AREA" +
                                                                                        ",TAS_DIARIA" +
                                                                                        ",CLAVE_EMISOR" +
                                                                                        ",T_INST" +
                                                                                        ",SECTOR" +
                                                                                        ",DXV_FCORTE" +
                                                                                        ",T_OPER" +
                                                                                        ",CVE_CONT" +
                                                                                        ",DXV_PAPEL" +
                                                                                        ",DURACION" +
                                                                                        ",PLAZO_OPER" +
                                                                                        ",VA_DRO" +
                                                                                        ",SOBRETASA) " +
                                                                                  "VALUES (to_date(:FECHA_CORTE,'yyyymmdd'),:EMISION ,:TV,:SERIE,:EMISOR,:OP, to_date(:FECHA_VAL,'yyyymmdd'), to_date(:FECHA_F_OPER,'yyyymmdd'),:NUM_OP,:CPRA_VTA,:TITULOS,:PRECIO_LIB,:VALOR_LIB,:DIAS_TRANS,:DXV,:TASA_VMTO ,:IMP_VMTO,:TASA_CVA_P,:PREMIO_DEV,:TASA_MERCA,:VPPV,:PRECIO_MERC,:VALOR_MERC,:PLAZO_PAPE,:TVMTOPAPEL,:INTERES_PA,:AREA,:TAS_DIARIA,'0',:T_INST,'0',:DXV_FCORTE,:T_OPER,:CVE_CONT,:DXV_PAPEL,:DURACION,:PLAZO_OPER,:VA_DRO,:SOBRETASA)";
                        cmd.CommandType = CommandType.Text;
                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexionRiesgos.Close();
            }
            return respuesta;
        }
        public Respuesta guardarReportePosicionTesoreria(List<ReportePosicionTesoreria> reporte, OracleConnection conexionRiesgos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;
            }

            borro = eliminarPosicionPosicionTesoreria(Convert.ToInt32(reporte[0].FechaCorte), conexionRiesgos);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexionRiesgos;

            try
            {
                if (borro)
                {
                    conexionRiesgos.Open();
                    int aff = 0;

                    foreach (ReportePosicionTesoreria item in reporte)
                    {
                        string fcort = "null";
                        string fvenc = "null";
                        string femis = "null";
                        string fcte = "null";

                        if (item.FechaCorte > 0)
                        {
                            fcort = item.FechaCorte.ToString();
                        }
                        if (item.FechaVto > 0)
                        {
                            fvenc = item.FechaVto.ToString();
                        }
                        if (item.FechaEmision > 0)
                        {
                            femis = item.FechaEmision.ToString();
                        }
                        if (item.FechaVtoCup > 0)
                        {
                            fcte = item.FechaVtoCup.ToString();
                        }
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("EMISION", item.Emision);
                        cmd.Parameters.Add("POSICION", item.Posicion);
                        cmd.Parameters.Add("OPERACION", item.Operacion);
                        cmd.Parameters.Add("FECHA_CORTE", fcort);
                        cmd.Parameters.Add("TITULOS", item.Titulos);
                        cmd.Parameters.Add("PRECIO_REF", "0");
                        cmd.Parameters.Add("FEC_VENC", fvenc);
                        cmd.Parameters.Add("TASA_MDO", item.TasaMercado);
                        cmd.Parameters.Add("PRECIO_LIBROS", item.PrecioLibros);
                        cmd.Parameters.Add("TASA_CPN", item.TasaCupon);
                        cmd.Parameters.Add("VN", item.ValorNominal);
                        cmd.Parameters.Add("FEC_EMISION", femis);
                        cmd.Parameters.Add("FEC_CTE_CPN", fcte);
                        cmd.Parameters.Add("CVE_INST", item.ClaveInstrumento);
                        cmd.Parameters.Add("CVE_EMISOR", "0");
                        cmd.Parameters.Add("DURACION", item.Duracion);
                        cmd.Parameters.Add("TIPO_TASA", item.TipoTasa);
                        cmd.Parameters.Add("MONEDA", item.Moneda);
                        cmd.Parameters.Add("AREA", item.Area);
                        cmd.Parameters.Add("TPZO_OPER", "0");
                        cmd.Parameters.Add("CVE_CONT", "0");
                        cmd.Parameters.Add("PZO_CPN", item.PlazoCupon);
                        cmd.Parameters.Add("PZO_REPO", item.PlazoRepo);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESGO.LIQ_TESORERIA (EMISION" +
                                                                    ",POSICION" +
                                                                    ",OPERACION" +
                                                                    ",FECHA_CORTE" +
                                                                    ",TITULOS" +
                                                                    ",PRECIO_REF" +
                                                                    ",FEC_VENC" +
                                                                    ",TASA_MDO" +
                                                                    ",PRECIO_LIBROS" +
                                                                    ",TASA_CPN" +
                                                                    ",VN" +
                                                                    ",FEC_EMISION" +
                                                                    ",FEC_CTE_CPN" +
                                                                    ",CVE_INST" +
                                                                    ",CVE_EMISOR" +
                                                                    ",DURACION" +
                                                                    ",TIPO_TASA" +
                                                                    ",MONEDA" +
                                                                    ",AREA" +
                                                                    ",TPZO_OPER" +
                                                                    ",CVE_CONT" +
                                                                    ",PZO_CPN" +
                                                                    ",PZO_REPO) " +
                                                        "VALUES (:EMISION,:POSICION,:OPERACION, to_date(:FECHA_CORTE,'yyyymmdd'),:TITULOS,:PRECIO_REF, to_date(:FEC_VENC,'yyyymmdd'),:TASA_MDO,:PRECIO_LIBROS,:TASA_CPN,:VN, to_date(:FEC_EMISION,'yyyymmdd'), to_date(:FEC_CTE_CPN,'yyyymmdd'),:CVE_INST,:CVE_EMISOR, :DURACION, :TIPO_TASA,:MONEDA,:AREA,:TPZO_OPER,:CVE_CONT, :PZO_CPN,:PZO_REPO)";

                        cmd.CommandType = CommandType.Text;
                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = false;
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexionRiesgos.Close();
            }
            return respuesta;
        }
        public Respuesta guardarPosicionGlobalTitulos(List<PosicionGlobalTitulos> reporte, OracleConnection conexion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;
            }

            borro = eliminarPosicionGlobalTitulos(Convert.ToInt32(reporte[0].Fecha), conexion);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                if (borro)
                {
                    conexion.Open();
                    int aff = 0;
                    foreach (PosicionGlobalTitulos item in reporte)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("Fecha", item.Fecha);
                        cmd.Parameters.Add("Emision", item.Emision);
                        cmd.Parameters.Add("TipoInventario", item.TipoInventario);
                        cmd.Parameters.Add("TotalTitulos", item.TotalTitulos);
                        cmd.Parameters.Add("TitulosRepIntermediarios", item.TitulosRepIntermediarios);
                        cmd.Parameters.Add("TitulosGarOtorgados", item.TitulosGarOtorgados);
                        cmd.Parameters.Add("TenenciaIndeval", item.TenenciaIndeval);
                        cmd.Parameters.Add("TitulosReportoCli", item.TitulosReportoCli);
                        cmd.Parameters.Add("TitulosEnAdmon", item.TitulosEnAdmon);
                        cmd.Parameters.Add("TitulosDisponibles", item.TitulosDisponibles);
                        cmd.Parameters.Add("TitulosGarRecibidos", item.TitulosGarRecibidos);
                        cmd.Parameters.Add("TitulosRecibidosCustodia", item.TitulosRecibidosCustodia);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESVARM.IKOS_POSICION_GLOBAL_TIT (Fecha" +
                                                                                        ",Emision" +
                                                                                        ",TipoInventario" +
                                                                                        ",TotalTitulos" +
                                                                                        ",TitulosRepIntermediarios" +
                                                                                        ",TitulosGarOtorgados" +
                                                                                        ",TenenciaIndeval" +
                                                                                        ",TitulosReportoCli" +
                                                                                        ",TitulosEnAdmon" +
                                                                                        ",TitulosDisponibles" +
                                                                                        ",TitulosGarRecibidos" +
                                                                                        ",TitulosRecibidosCustodia)" +
                                                                                        " VALUES (:Fecha,:Emision,:TipoInventario,:TotalTitulos,:TitulosRepIntermediarios,:TitulosGarOtorgados,:TenenciaIndeval,:TitulosReportoCli,:TitulosEnAdmon,:TitulosDisponibles,:TitulosGarRecibidos,:TitulosRecibidosCustodia)";
                        cmd.CommandType = CommandType.Text;
                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
        public Respuesta guardarMovimientosTesoreria(List<MovimientosTesoreria> reporte, OracleConnection conexionRiesgos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;
            }

            borro = eliminarMovimientosTesoreria(Convert.ToInt32(reporte[0].FechaAlta), conexionRiesgos);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexionRiesgos;

            try
            {
                if (borro)
                {
                    conexionRiesgos.Open();
                    int aff = 0;
                    foreach (MovimientosTesoreria item in reporte)
                    {

                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("IDENTIFICADOR", item.Identificador);
                        cmd.Parameters.Add("NOMINSTRUMENTO", '0');//item.NomInstrumento
                        cmd.Parameters.Add("EMISOR", item.Emisor);
                        cmd.Parameters.Add("NOMEMI", item.Emision);
                        cmd.Parameters.Add("CLAVEOPER", item.ClaveOper);
                        cmd.Parameters.Add("TIPOMOV", item.TipoMov);
                        cmd.Parameters.Add("NUMTITASIG", item.NumTitAsig);
                        cmd.Parameters.Add("PRECIODEREF", item.PrecioRef);
                        cmd.Parameters.Add("PRECIOLIBROS", item.PrecioLibros);
                        cmd.Parameters.Add("IMPASIG", item.ImporteAsig);
                        cmd.Parameters.Add("TASACOSTO", item.TasaCosto);
                        cmd.Parameters.Add("PLAZO", item.Plazo);
                        cmd.Parameters.Add("FECHAALTA", item.FechaAlta);
                        cmd.Parameters.Add("FECHAVENC", item.FechaVen);
                        cmd.Parameters.Add("TITGARAN", item.TitGarant);
                        cmd.Parameters.Add("PERIODO", item.Periodo);
                        cmd.Parameters.Add("TASAREF", item.TasaRef);
                        cmd.Parameters.Add("EMISIONGAR", item.EmisionGar);
                        cmd.Parameters.Add("NUMFUNCIONARIO", '0');//item.NumFuncionario
                        cmd.Parameters.Add("NUMCONTRAPARTE", item.NumContraparte);
                        cmd.Parameters.Add("NUMOPER", item.NumOper);
                        cmd.Parameters.Add("FECHAEXP", item.FechaExp);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESGO.POS_TESO (IDENTIFICADOR" +
                                                                                    ",NOMINSTRUMENTO" +
                                                                                    ",EMISOR" +
                                                                                    ",NOMEMI" +
                                                                                    ",CLAVEOPER" +
                                                                                    ",TIPOMOV" +
                                                                                    ",NUMTITASIG" +
                                                                                    ",PRECIODEREF" +
                                                                                    ",PRECIOLIBROS" +
                                                                                    ",IMPASIG" +
                                                                                    ",TASACOSTO" +
                                                                                    ",PLAZO" +
                                                                                    ",FECHAALTA" +
                                                                                    ",FECHAVENC" +
                                                                                    ",TITGARAN" +
                                                                                    ",PERIODO" +
                                                                                    ",TASAREF" +
                                                                                    ",EMISIONGAR" +
                                                                                    ",NUMFUNCIONARIO" +
                                                                                    ",NUMCONTRAPARTE" +
                                                                                    ",NUMOPER" +
                                                                                    ",FECHAEXP) " +
                                                                           "VALUES (:IDENTIFICADOR,'0' ,:EMISOR,:NOMEMI,:CLAVEOPER,:TIPOMOV,:NUMTITASIG,:PRECIODEREF,:PRECIOLIBROS,:IMPASIG,:TASACOSTO,:PLAZO, to_date(:FECHAALTA,'yyyymmdd'), to_date(:FECHAVENC,'yyyymmdd'),:TITGARAN,:PERIODO,:TASAREF,:EMISIONGAR, '0',:NUMCONTRAPARTE,:NUMOPER, to_date(:FECHAEXP,'yyyymmdd'))";


                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = false;
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexionRiesgos.Close();
            }
            return respuesta;
        }
        public Respuesta guardarComprasVentasOperador(List<ComprasVentasOperador> reporte, OracleConnection conexion, int fechaIni, int fechaFin)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;
            }

            borro = eliminarComprasVentasOperador(conexion, fechaIni, fechaFin);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                if (borro)
                {
                    conexion.Open();
                    int aff = 0;
                    foreach (ComprasVentasOperador item in reporte)
                    {

                        cmd.Parameters.Add("FechaConcertacion", item.FechaConcertacion);
                        cmd.Parameters.Add("Contraparte", item.Contraparte);
                        cmd.Parameters.Add("Contrato", item.Contrato);
                        cmd.Parameters.Add("TipoValor", item.TipoValor);
                        cmd.Parameters.Add("Emisor", item.Emisor);
                        cmd.Parameters.Add("Serie", item.Serie);
                        cmd.Parameters.Add("ClaveOper", item.ClaveOper);
                        cmd.Parameters.Add("TipoOper", item.TipoOper);
                        cmd.Parameters.Add("ImporteAsignado", item.ImporteAsignado);
                        cmd.Parameters.Add("ImporteCierre", item.ImporteCierre);
                        cmd.Parameters.Add("Parte", item.Parte);
                        cmd.Parameters.Add("Usuario", item.Usuario);
                        cmd.BindByName = true;

                        cmd.CommandText = "INSERT INTO RIESVARM.COMPRAS_VENTAS_OPER (FechaConcertacion" +
                                                    ",Contraparte" +
                                                    ",Contrato" +
                                                    ",TipoValor" +
                                                    ",Emisor" +
                                                    ",Serie" +
                                                    ",ClaveOper" +
                                                    ",TipoOper" +
                                                    ",ImporteAsignado" +
                                                    ",ImporteCierre" +
                                                    ",Parte" +
                                                    ",Usuario)" +
                                                    "VALUES (:FechaConcertacion, :Contraparte, :Contrato, :TipoValor, :Emisor, :Serie, :ClaveOper, :TipoOper, :ImporteAsignado, :ImporteCierre, :Parte, :Usuario)";

                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = false;
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
        public Respuesta guardarReporteMDCambios(List<ReporteMDCambios> reporte, OracleConnection conexionRiesgos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            bool borro = false;

            if (reporte.Count <= 0)
            {
                respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                return respuesta;
            }

            borro = eliminarReporteMDCambios(Convert.ToInt32(reporte[0].Fecha), conexionRiesgos);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexionRiesgos;

            try
            {
                if (borro)
                {
                    conexionRiesgos.Open();
                    int aff = 0;
                    foreach (ReporteMDCambios item in reporte)
                    {

                        cmd.Parameters.Clear();

                        cmd.BindByName = true;


                        aff += cmd.ExecuteNonQuery();
                    }

                    respuesta.exito = true;
                    respuesta.mensaje = aff + " registros fueron insertados.";
                }
                else
                {
                    respuesta.mensaje = "Hubo un error al borrar los registros.";
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = false;
                respuesta.mensaje = "Hubo un error al insertar los registros. " + ex.Message;
            }
            finally
            {
                conexionRiesgos.Close();
            }
            return respuesta;
        }
        public bool eliminarValuacionReportos(int fechaConsulta, OracleConnection conexion)
        {
            Respuesta respuesta = new Respuesta();
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                cmd.Parameters.Add("FECHAVALUACION", fechaConsulta);
                cmd.BindByName = true;
                int aff = 0;
                cmd.CommandText = String.Format("DELETE FROM RIESVARM.IKOS_VAL_REPORTOS WHERE FECHAVALUACION = :FECHAVALUACION", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception ex)
            {
                exito = false;
                respuesta.mensaje = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarTenenciaTitulos(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("FECHAVALUACION", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESVARM.IKOS_TENENCIA_TITULOS WHERE FECHAVALUACION = :FECHAVALUACION", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarComprasMesaDinero(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("FechaValor", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESVARM.IKOS_COMPRAS_MD WHERE FECHAVALOR = :FechaValor", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarComprasTesoreria(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("FechaValor", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESVARM.IKOS_COMPRAS_TESO WHERE FECHAVALOR = :FechaValor", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarPosicionPatrimonial(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("FechaValuacion", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESVARM.IKOS_PATRIMONIAL WHERE FECHAVALUACION = :FechaValuacion", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarReporteREVAME(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("Fecha", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESVARM.IKOS_REVAME WHERE FECHA = :Fecha", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarPosicionCalculoVAR(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("F_POSICION", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESGO.POS_MESA_TESO WHERE F_POSICION = :F_POSICION", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarPosicionRegulatorios(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("FECHA_CORTE", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESGO.LIQ_REPORTOS WHERE FECHA_CORTE = to_date(:FECHA_CORTE,'yyyymmdd')", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarPosicionPosicionTesoreria(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("FECHA_CORTE", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESGO.LIQ_TESORERIA WHERE FECHA_CORTE = to_date(:FECHA_CORTE,'yyyymmdd')", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarPosicionGlobalTitulos(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("FECHA", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESVARM.IKOS_POSICION_GLOBAL_TIT WHERE FECHA = :FECHA", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarMovimientosTesoreria(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("FECHAALTA", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESGO.POS_TESO WHERE FECHAALTA = to_date(FECHAALTA,'yyyymmdd')", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarComprasVentasOperador(OracleConnection conexion, int fechaIni, int fechaFin)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("FechaConcertacion", fechaIni);
                cmd.Parameters.Add("Contraparte", fechaFin);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESVARM.COMPRAS_VENTAS_OPER WHERE FechaConcertacion >= :FechaConcertacion AND FechaConcertacion <= :Contraparte", fechaIni, fechaFin);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
        public bool eliminarReporteMDCambios(int fechaConsulta, OracleConnection conexion)
        {
            bool exito = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                int aff = 0;
                cmd.Parameters.Add("Fecha", fechaConsulta);
                cmd.BindByName = true;
                cmd.CommandText = String.Format("DELETE FROM RIESGO.LIQ_MDO_CAMBIOS WHERE Fecha = :Fecha", fechaConsulta);

                aff = cmd.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
            return exito;
        }
    }
}

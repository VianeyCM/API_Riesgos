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
                        cmd.Parameters.Add("DXVRC02", item.DXVRC02);
                        cmd.Parameters.Add("PlusMinus", item.PlusMinus);
                        cmd.Parameters.Add("TasaCosto", item.TasaCosto);
                        cmd.Parameters.Add("Parte", item.Parte);
                        cmd.BindByName = true;
                        cmd.CommandText = "INSERT INTO RIESVARM.IKOS_TENENCIA_TITULOS (FECHAVALUACION,EMISION,TITULOS,ImporteSucio,TIPO,Descripcion,PORTAFOLIO,NumOperacion,InteresDevengado,TitulosGarantia,Intercupon,DXVencer,DXVRC0103,PrecioSucio,PrecioLimpio,ImporteLimpio,ImporteInteres,PrecioMercado,ImporteMercado,DXVRC02,PlusMinus,TasaCosto,Parte) VALUES (FECHAVALUACION,:EMISION,:TITULOS,:ImporteSucio,:TIPO,:Descripcion,:PORTAFOLIO,:NumOperacion,:InteresDevengado,:TitulosGarantia,:Intercupon,:DXVencer,:DXVRC0103,:PrecioSucio,:PrecioLimpio,:ImporteLimpio,:ImporteInteres,:PrecioMercado,:ImporteMercado,:DXVRC02,:PlusMinus,:TasaCosto,:Parte)";
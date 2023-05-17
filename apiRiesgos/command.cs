
                        //cmd.CommandText = "INSERT INTO RIESVARM.IKOS_COMPRAS_MD (FechaValor,Moneda,NumOperacion,Contraparte,Papel,Emision,Posicion,FV,NumTitulos,PrecioSucio,TasaRend,TasaDiaria,Plazo,ImporteReal,PORTAFOLIO) VALUES (:FechaValor ,:Moneda ,:NumOperacion ,:Contraparte ,:Papel ,:Emision ,:Posicion ,:FV ,:NumTitulos ,:PrecioSucio ,:TasaRend ,:TasaDiaria ,:Plazo ,:ImporteReal ,:Portafolio)";           
                        // cmd.CommandText = "Insert into RIESVARM.IKOS_COMPRAS_MD (FECHAVALOR,MONEDA,NUMOPERACION,CONTRAPARTE,PAPEL,EMISION,POSICION,FV,NUMTITULOS,PRECIOSUCIO,TASAREND,TASADIARIA,PLAZO,IMPORTEREAL,PORTAFOLIO) values (FechaValor,Moneda,NumOperacion,Contraparte,Papel,Emision,Posicion,FV,NumTitulos,PrecioSucio,TasaRend,TasaDiaria,Plazo,ImporteReal,Portafolio)";
                        cmd.CommandText = "Insert into RIESVARM.IKOS_COMPRAS_MD (FECHAVALOR,MONEDA,NUMOPERACION,CONTRAPARTE,PAPEL,EMISION,POSICION,FV,NUMTITULOS,PRECIOSUCIO,TASAREND,TASADIARIA,PLAZO,IMPORTEREAL,PORTAFOLIO) values  ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, {9}, {10}, {11}, {12}, {13}, '{14}')";

                        cmd.Parameters.Add(new OracleParameter("FechaValor", OracleDbType.Varchar2, item.FechaValor, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("Moneda", OracleDbType.Varchar2, item.Moneda, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("NumOperacion", OracleDbType.Varchar2, item.NumOperacion, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("Contraparte", OracleDbType.Varchar2, item.Contraparte, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("Papel", OracleDbType.Varchar2, item.Papel, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("Emision", OracleDbType.Varchar2, item.Emision, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("Posicion", OracleDbType.Varchar2, item.Posicion, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("FV", OracleDbType.Varchar2, item.FV, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("NumTitulos", OracleDbType.Varchar2, item.NumTitulos, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("PrecioSucio", OracleDbType.Decimal, item.PrecioSucio, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("TasaRend", OracleDbType.Decimal, item.TasaRend, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("TasaDiaria", OracleDbType.Decimal, item.TasaDiaria, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("Plazo", OracleDbType.Decimal, item.Plazo, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("ImporteReal", OracleDbType.Decimal, item.ImporteReal, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("Portafolio", OracleDbType.Varchar2, item.Portafolio, ParameterDirection.Input));

                        /* cmd.Parameters.Add(new OracleParameter("FechaValor", OracleDbType.Varchar2)).Value = item.FechaValor;
                         cmd.Parameters.Add(new OracleParameter("Moneda", OracleDbType.Varchar2)).Value = item.Moneda;
                         cmd.Parameters.Add(new OracleParameter("NumOperacion", OracleDbType.Varchar2)).Value = item.NumOperacion;
                         cmd.Parameters.Add(new OracleParameter("Contraparte", OracleDbType.Varchar2)).Value = item.Contraparte;
                         cmd.Parameters.Add(new OracleParameter("Papel", OracleDbType.Varchar2)).Value = item.Papel;
                         cmd.Parameters.Add(new OracleParameter("Emision", OracleDbType.Varchar2)).Value = item.Emision;
                         cmd.Parameters.Add(new OracleParameter("Posicion", OracleDbType.Varchar2)).Value = item.Posicion;
                         cmd.Parameters.Add(new OracleParameter("FV", OracleDbType.Varchar2)).Value = item.FV;
                         cmd.Parameters.Add(new OracleParameter("NumTitulos", OracleDbType.Varchar2)).Value = item.NumTitulos;
                         cmd.Parameters.Add(new OracleParameter("PrecioSucio", OracleDbType.Decimal)).Value = item.PrecioSucio;
                         cmd.Parameters.Add(new OracleParameter("TasaRend", OracleDbType.Decimal)).Value = item.TasaRend;
                         cmd.Parameters.Add(new OracleParameter("TasaDiaria", OracleDbType.Decimal)).Value = item.TasaDiaria;
                         cmd.Parameters.Add(new OracleParameter("Plazo", OracleDbType.Varchar2)).Value = item.Plazo;
                         cmd.Parameters.Add(new OracleParameter("ImporteReal", OracleDbType.Decimal)).Value = item.ImporteReal;
                         cmd.Parameters.Add(new OracleParameter("PORTAFOLIO", OracleDbType.Varchar2)).Value = item.Portafolio;
                         */
        
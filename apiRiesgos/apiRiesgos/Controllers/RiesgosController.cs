using apiRiesgos.Servicios;
using DAL;
using ENTITY;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using Oracle.ManagedDataAccess.Client;
using System.Reflection;

namespace apiRiesgos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiesgosController : Controller
    {
        private readonly IServicio_API _servicioApi;
        private readonly ILogger<RiesgosController> _logger;
        private readonly IConfiguration _config;
        string? conexion;
        string? conexionRiesgos;
        string? conexionRiesvarm;
        Respuesta respuesta1 = new Respuesta();

        public RiesgosController(IServicio_API servicioApi, ILogger<RiesgosController> logger)
        {
            _servicioApi = servicioApi;
            _logger = logger;
            try
            {

                IConfiguration config = new ConfigurationBuilder().AddUserSecrets("e2269dbe-bb56-41ae-ab27-d92d8ffe8d38").Build();

                conexion = config["ConnectionStrings:Connection"];
                conexionRiesgos = config.GetValue<string>("ConnectionStrings:ConnectionRiesgos");
                //conexionRiesgos = config["ConnectionStrings:ConnectionRiesgos"]; 
                conexionRiesvarm = config["ConnectionStrings:ConnectionRiesvarm"];
            }
            catch (Exception ex)
            {
                respuesta1.mensaje = ex.Message;
            }


            //string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        }
        [HttpGet("{tipoReporte}/{fechaConsulta}/{token}")]
        public async Task<Respuesta> GetRiesgos(int tipoReporte, int fechaConsulta, string token)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.exito = false;
            ResultadoAPI respuestaAPI = new ResultadoAPI();
            if (tipoReporte == 1)
            {
                OracleConnection con = new OracleConnection(conexion);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                    respuestaAPI.mensaje = respuesta1.mensaje + "--" + conexion;
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaValuacionReportos != null)
                {
                    respuesta = new DALRiesgos().guardarValuacionReportos(respuestaAPI.listaValuacionReportos, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 2)
            {
                OracleConnection con = new OracleConnection(conexion);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaTenenciaTitulos != null)
                {
                    respuesta = new DALRiesgos().guardarTenenciaTitulos(respuestaAPI.listaTenenciaTitulos, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 3)
            {
                OracleConnection con = new OracleConnection(conexion);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaComprasMesaDinero != null)
                {
                    respuesta = new DALRiesgos().guardarComprasMesaDinero(respuestaAPI.listaComprasMesaDinero, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 4)
            {
                OracleConnection con = new OracleConnection(conexion);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaComprasTesoreria != null)
                {
                    respuesta = new DALRiesgos().guardarComprasTesoreria(respuestaAPI.listaComprasTesoreria, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 5)
            {
                OracleConnection con = new OracleConnection(conexion);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaPosicionPatrimonial != null)
                {
                    respuesta = new DALRiesgos().guardarPosicionPatrimonial(respuestaAPI.listaPosicionPatrimonial, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 7)
            {
                OracleConnection con = new OracleConnection(conexion);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaReporteREVAME != null)
                {
                    respuesta = new DALRiesgos().guardarReporteREVAME(respuestaAPI.listaReporteREVAME, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 8)
            {
                OracleConnection con = new OracleConnection(conexionRiesgos);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaPosicionCalculoVAR != null)
                {
                    respuesta = new DALRiesgos().guardarPosicionCalculoVAR(respuestaAPI.listaPosicionCalculoVAR, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 9)
            {
                OracleConnection con = new OracleConnection(conexionRiesgos);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaPosicionRegulatorios != null)
                {
                    respuesta = new DALRiesgos().guardarPosicionRegulatorios(respuestaAPI.listaPosicionRegulatorios, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 10)
            {
                OracleConnection con = new OracleConnection(conexionRiesgos);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaReportePosicionTesoreria != null)
                {
                    respuesta = new DALRiesgos().guardarReportePosicionTesoreria(respuestaAPI.listaReportePosicionTesoreria, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 11)
            {
                OracleConnection con = new OracleConnection(conexion);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaPosicionGlobalTitulos != null)
                {
                    respuesta = new DALRiesgos().guardarGlobalTitulos(respuestaAPI.listaPosicionGlobalTitulos, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 12)
            {
                OracleConnection con = new OracleConnection(conexionRiesgos);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaMovimientosTesoreria != null)
                {
                    respuesta = new DALRiesgos().guardarMovimientosTesoreria(respuestaAPI.listaMovimientosTesoreria, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else if (tipoReporte == 13)
            {
                OracleConnection con = new OracleConnection(conexion);
                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgos(tipoReporte, fechaConsulta, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }
                if (respuestaAPI.listaReporteMDCambios != null)
                {
                    respuesta = new DALRiesgos().guardarReporteMDCambios(respuestaAPI.listaReporteMDCambios, con);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else
            {
                respuesta.mensaje = "El número de reporte es invalido.";
            }

            return respuesta;
        }
        [HttpGet("{tipoReporte}/{fechaIni}/{fechaFin}/{token}")]
        public async Task<Respuesta> GetRiesgosRango(int tipoReporte, int fechaIni, int fechaFin, string token)
        {
            Respuesta respuesta = new Respuesta();
            ResultadoAPI respuestaAPI = new ResultadoAPI();
            if (tipoReporte == 6)
            {
                OracleConnection con = new OracleConnection(conexion);

                try
                {
                    respuestaAPI = await _servicioApi.GetRiesgosRango(tipoReporte, fechaIni, fechaFin, token);
                }
                catch (Exception ex)
                {
                    respuesta.mensaje = "Error: " + ex.Message + "--" + respuestaAPI.mensaje;
                }

                if (respuestaAPI.listaComprasVentasOperador != null)
                {
                    respuesta = new DALRiesgos().guardarComprasVentasOperador(respuestaAPI.listaComprasVentasOperador, con, fechaIni, fechaFin);
                }
                else
                {
                    respuesta.mensaje = "No hay registros en SIMEFIN para insertar en la base de datos.";
                }
            }
            else
            {
                respuesta.mensaje = "El número de reporte es invalido.";
            }

            return respuesta;
        }
    }
}

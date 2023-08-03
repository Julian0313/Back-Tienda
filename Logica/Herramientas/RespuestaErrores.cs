using Dominio.Entidades;

namespace Logica.Herramientas
{
    public class RespuestaErrores
    {
        public static Respuesta<T> RespuestaOkay<T>(T datos)
        {
            return new Respuesta<T>() 
            {
                CodigoEstado = System.Net.HttpStatusCode.OK,
                Datos = datos,
                Mensaje = "Proceso exitoso"
            };
        }

        public static Respuesta<T> RespuestaSinRegistros<T>(string mensaje)
        {
            return new Respuesta<T>()
            {
                CodigoEstado = System.Net.HttpStatusCode.NotFound,
                Mensaje = mensaje
            };
        }
        public static Respuesta<T> RespuestaError<T>(T datos)
        {
            return new Respuesta<T>()
            {
                CodigoEstado = System.Net.HttpStatusCode.BadRequest,
                Mensaje = "Error en el proceso",
                Datos = datos
            };
        }
    }
}
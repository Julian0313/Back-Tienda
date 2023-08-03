using System.Net;

namespace Dominio.Entidades
{
    public class Respuesta<T>
    {
        public string Mensaje { get; set; }
        public HttpStatusCode CodigoEstado { get; set; }
        public T Datos { get; set; }


    }
}
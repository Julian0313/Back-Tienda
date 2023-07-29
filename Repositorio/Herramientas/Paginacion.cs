namespace Repositorio.Herramientas
{
    public class Paginacion<T> where T : class
    {
        public Paginacion(int pageIndex, int pageSize, int contador, IReadOnlyList<T> datos)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Contador = contador;
            Datos = datos;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Contador { get; set; }
        public IReadOnlyList<T> Datos { get; set; }
    }
}
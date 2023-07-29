﻿namespace Dominio.Entidades
{
    public class ProductoDTO
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public string imagenUrl { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }        
        public int fkIdEstado { get; set; }       
        public int fkIdCategoria { get; set; }
    }
}

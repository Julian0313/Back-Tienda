namespace Dominio.Entidades
{
    public class Empleado
    {
        public int idEmpleado { get; set; }           
        public int fkIdCargo { get; set; }
        public int fkIdEstado { get; set; }
        public string documento { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }     
        public DateTime fechaCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
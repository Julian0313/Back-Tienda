namespace Dominio.Entidades
{
    public class EmpleadoRtn
    {
        public int idEmpleado { get; set; }           
        public string fkIdCargo { get; set; }
        public string fkIdEstado { get; set; }
        public string documento { get; set; }
        public string primerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }     
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}
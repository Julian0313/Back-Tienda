namespace Dominio.Entidades
{

	public class Usuario
	{
		public int idUsuario { get; set; }
		public string usuario { get; set; }
		public string contrasena { get; set; }
		public DateTime fechaCreacion { get; set; }
		public DateTime? fechaModificacion { get; set; }
		public int fkIdRol { get; set; }
		public Rol Rol { get; set; }
		public int fkIdEstado { get; set; }
		public Estado Estado { get; set; }
	}
}
namespace Dominio.Entidades
{

	public class UsuarioRtn
	{
		public int idUsuario { get; set; }
		public string usuario { get; set; }
		public string contrasena { get; set; }
		public DateTime fechaCreacion { get; set; }
		public DateTime? fechaModificacion { get; set; }
		public string fkIdRol { get; set; }
		public string fkIdEstado { get; set; }
	}
}
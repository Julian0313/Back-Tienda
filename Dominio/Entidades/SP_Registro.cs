namespace Dominio.Entidades
{
	public class SP_Registro
	{
		public string identificacion { get; set; }
		public string primerNombre { get; set; }
		public string segundoNombre { get; set; }
		public string primerApellido { get; set; }
		public string segundoApellido { get; set; }
		public string email { get; set; }
		public string direccion { get; set; }
		public string celular { get; set; }
		public string contrasena { get; set; }
		public int fkIdRol { get; set; }
	}
}
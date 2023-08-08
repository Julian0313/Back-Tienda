namespace Dominio.Entidades
{
	public class ClienteRtn
	{
		public int idCliente { get; set; }
		public string identificacion { get; set; }
		public string primerNombre { get; set; }
		public string segundoNombre { get; set; }
		public string primerApellido { get; set; }
		public string segundoApellido { get; set; }
		public string email { get; set; }
		public string direccion { get; set; }
		public string celular { get; set; }
		public DateTime fechaCreacion { get; set; }
		public DateTime fechaModificacion { get; set; }
		public string fkIdEstado { get; set; }
		public string fkIdUsuario { get; set; }
	}
}
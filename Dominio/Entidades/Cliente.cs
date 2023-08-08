namespace Dominio.Entidades
{
	public class Cliente
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
		public DateTime? fechaModificacion { get; set; }
		public int fkIdEstado { get; set; }
		public virtual Estado Estado { get; set; }
		public int fkIdUsuario { get; set; }		
		public virtual Usuario Usuario { get; set; }
	}
}
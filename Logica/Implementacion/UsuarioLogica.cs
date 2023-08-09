using Dominio.Entidades;
using Logica.Herramientas;
using Logica.Interfaz;
using Repositorio.Herramientas;
using Repositorio.Interfaz;

namespace Logica.Implementacion
{
    public class UsuarioLogica : IUsuarioLogica
    {
        private readonly IUsuarioRepositorio _usuarioRepo;
        public UsuarioLogica(IUsuarioRepositorio usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<Respuesta<IEnumerable<Usuario>>> ObtenerUsuarioLogica(Parametros parametros)
        {
            IEnumerable<Usuario> usuario = await _usuarioRepo.ObtenerUsuarioAsync(parametros);
            return usuario != null ?
            RespuestaErrores.RespuestaOkay(usuario) :
            RespuestaErrores.RespuestaSinRegistros<IEnumerable<Usuario>>("No existe usuario con este correo");
        }
    }
}
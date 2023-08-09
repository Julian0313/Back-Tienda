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

        public async Task<Respuesta<IEnumerable<UsuarioRtn>>> ObtenerUsuarioLogica(string buscar)
        {
            IEnumerable<UsuarioRtn> usuario = await _usuarioRepo.ObtenerUsuarioAsync(buscar);
            return usuario != null ?
            RespuestaErrores.RespuestaOkay(usuario) :
            RespuestaErrores.RespuestaSinRegistros<IEnumerable<UsuarioRtn>>("No existe usuario con este correo");
        }
    }
}
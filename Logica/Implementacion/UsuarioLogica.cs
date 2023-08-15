using Dominio.Entidades;
using Logica.Herramientas;
using Logica.Interfaz;
using Repositorio.Herramientas;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;

namespace Logica.Implementacion
{
    public class UsuarioLogica : IUsuarioLogica
    {
        private readonly IUsuarioRepositorio _usuarioRepo;
        private readonly IUnidadTrabajo _unidadTrabajo;
        public UsuarioLogica(IUsuarioRepositorio usuarioRepo, IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            _usuarioRepo = usuarioRepo;
        }

        public async Task<Respuesta<UsuarioRtn>> ObtenerUsuarioLogica(string buscar)
        {
            UsuarioRtn usuario = await _usuarioRepo.ObtenerUsuarioAsync(buscar);
            return usuario != null ?
            RespuestaErrores.RespuestaOkay(usuario) :
            RespuestaErrores.RespuestaSinRegistros<UsuarioRtn>("No existe usuario con este correo");
        }

        public async Task<Respuesta<string>> EditarUsuarioLogica(Usuario usuario)
        {
            var editarUsuario = await _usuarioRepo.ObtenerUsuarioAsync(usuario.usuario);

            if(editarUsuario == null)
            {
                return RespuestaErrores.RespuestaError<string>("No exsiste un usuario : "+ usuario.usuario);
            }
            
            await _usuarioRepo.EditarUsuarioAsync(usuario);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Contraseña actualizada correctamente. Usuario : " + usuario.usuario);
        }

        public async Task<bool> ValidarUsuarioLogica(Usuario request)
        {
            var validarUsuario = await _usuarioRepo.ObtenerUsuarioAsync(request.usuario);

            // if(validarUsuario != null && 
            //     validarUsuario.usuario == request.usuario && 
            //     validarUsuario.contrasena == request.contrasena)
            // {
            //     return true;
            // }
            // else
            // {
            //     return false;
            // }
            return validarUsuario != null && validarUsuario.usuario == request.usuario && validarUsuario.contrasena == request.contrasena;
            
        }
    }
}
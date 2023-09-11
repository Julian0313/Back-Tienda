using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dominio.Entidades;
using Logica.Herramientas;
using Logica.Interfaz;
using Microsoft.IdentityModel.Tokens;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;
using Microsoft.Extensions.Configuration;


namespace Logica.Implementacion
{
    public class UsuarioLogica : IUsuarioLogica
    {
        private readonly IUsuarioRepositorio _usuarioRepo;
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly string secretKey;
        public UsuarioLogica(IUsuarioRepositorio usuarioRepo, IUnidadTrabajo unidadTrabajo, IConfiguration config)
        {
            _unidadTrabajo = unidadTrabajo;
            _usuarioRepo = usuarioRepo;
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
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

            if (editarUsuario == null)
            {
                return RespuestaErrores.RespuestaError<string>("No exsiste un usuario : " + usuario.usuario);
            }

            await _usuarioRepo.EditarUsuarioAsync(usuario);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Contraseña actualizada correctamente. Usuario : " + usuario.usuario);
        }

        public async Task<Respuesta<string>> ValidarUsuarioLogica(string usuario, string contrasena)
        {
            var validarUsuario = await _usuarioRepo.ObtenerUsuarioAsync(usuario);

            if (validarUsuario != null &&
                validarUsuario.usuario == usuario &&
                BCrypt.Net.BCrypt.Verify(contrasena, validarUsuario.contrasena))
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return RespuestaErrores.RespuestaOkay<string>(tokenCreado);

            }
            else
            {
                var tresMesesAtras = DateTime.Now.AddMonths(-3);
                if (validarUsuario.fechaModificacion > tresMesesAtras)
                {
                    var tiempoTranscurrido = DateTime.Now - validarUsuario.fechaModificacion;
                    if (tiempoTranscurrido.HasValue)
                    {
                        int dias = (int)tiempoTranscurrido.Value.TotalDays;
                        int meses = (int)(dias / 31);

                        if (meses == 0)
                        {
                            return RespuestaErrores.RespuestaError<string>("Cambio su contraseña hace: " + dias + " dias");
                        }
                        else if (meses <= 3)
                        {
                            return RespuestaErrores.RespuestaError<string>("Cambio su contraseña hace: " + meses + " meses");
                        }
                    }
                }
                return RespuestaErrores.RespuestaError<string>("No autorizado");

            }
        }
    }
}
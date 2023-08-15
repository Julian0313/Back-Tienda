using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dominio.Entidades;
using Logica.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioLogica _usuarioLog;
        private readonly string secretKey;
        public UsuarioController(IUsuarioLogica usuarioLog, IConfiguration config)
        {
            _usuarioLog = usuarioLog;
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
        }

        [HttpGet]
        [Route("Obtener-Usuario")]
        public async Task<IActionResult> ObtenerUsuario([FromQuery] string buscar)
        {
            return Ok(await _usuarioLog.ObtenerUsuarioLogica(buscar));
        }

        [HttpPut]
        [Route("Editar-Usuario")]
        public async Task<IActionResult> EditarUsuario(Usuario usuario)
        {
            return Ok(await _usuarioLog.EditarUsuarioLogica(usuario));
        }

        [HttpPost]
        [Route("Validar")]
        public IActionResult Validar([FromQuery] Usuario request)
        {
            var validarUsuario = _usuarioLog.ValidarUsuarioLogica(request);

            if (validarUsuario.Result == true)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.usuario));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });

            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }
    }
}
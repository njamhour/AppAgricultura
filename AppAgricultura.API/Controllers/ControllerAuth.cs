using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AppAgricultura.API.Data;
using AppAgricultura.API.Dtos;
using AppAgricultura.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AppAgricultura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerAuth : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public ControllerAuth(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(RegistrarUsuarioDto registrarUsuarioDto)
        {
            registrarUsuarioDto.Login = registrarUsuarioDto.Login.ToLower();

            if (await _repo.UsuarioExiste(registrarUsuarioDto.Login))
                return BadRequest("Usuário já existe");

            var CriarUsuario = new Usuario
            {
                Login = registrarUsuarioDto.Login
            };

            var usuarioCriado = await _repo.Registrar(CriarUsuario, registrarUsuarioDto.Senha);

            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto loginUsuarioDto)
        {
            var usuarioRepo = await _repo.Login(loginUsuarioDto.Login, loginUsuarioDto.Senha);
            if (usuarioRepo == null)
                return Unauthorized();

            var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuarioRepo.Login)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });


        }

    }
}
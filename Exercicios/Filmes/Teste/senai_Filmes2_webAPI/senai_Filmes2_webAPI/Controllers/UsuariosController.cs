using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_Filmes2_webAPI.Domains;
using senai_Filmes2_webAPI.Interfaces;
using senai_Filmes2_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_Filmes2_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository(); 
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            // ! -> não
            // != -> não igual, ou seja, diferente
            // == -> igual
            if (usuarioBuscado != null)
            {
                //return Ok(usuarioBuscado);

                // Dados - Payload
                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.permissao)
                };

                //Chave
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

                //Credencias - signature

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //composicao do token 
                var meuToken = new JwtSecurityToken(
                    issuer: "Filmes2.webAPI",      //Emissor do token
                    audience: "Filmes2.webAPI",     //Destiantario do token
                    claims: minhasClaims,          //Dados que definimos acima
                    expires: DateTime.Now.AddMinutes(30),      //Tempo de expiacao do token
                    signingCredentials: creds      //Credenciais do Token

                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });

            }

            return NotFound("Email ou senha nao encontrados");
            

        }

    }
}

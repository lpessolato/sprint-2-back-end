using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_Filmes2_webAPI.Domains;
using senai_Filmes2_webAPI.Interfaces;
using senai_Filmes2_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public IActionResult login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
                return NotFound("Email ou senha INvalidos!");

            return Ok(usuarioBuscado);




        }

    }
}

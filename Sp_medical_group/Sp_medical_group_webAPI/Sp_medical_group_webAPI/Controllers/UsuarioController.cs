using Microsoft.AspNetCore.Mvc;
using Sp_medical_group_webAPI.Domains;
using Sp_medical_group_webAPI.Interfaces;
using Sp_medical_group_webAPI.Repositories;
using System.Collections.Generic;

namespace Sp_medical_group_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {

            List<Usuario> listarUsuario = _usuarioRepository.Listar();
            return Ok(listarUsuario);
        }


        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201);
        }

        [HttpPut("{idUsuario}")]

        public IActionResult Atualizar (int idUsuario, Usuario usuarioAtualizado)
        {
            _usuarioRepository.Atualizar(idUsuario, usuarioAtualizado);
            return StatusCode(204);
        }

        [HttpDelete("excluir/{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _usuarioRepository.Deletar(idUsuario);
            return StatusCode(204);
        }

    }
}

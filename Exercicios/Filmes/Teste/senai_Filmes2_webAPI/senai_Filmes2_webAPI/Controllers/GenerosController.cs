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
    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _GeneroRepository { get; set; } 
        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }
        [HttpGet]

        public IActionResult Get()
        {
            List<GeneroDomain> listaGeneros = _GeneroRepository.ListarTodos();
            return Ok(listaGeneros);
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            _GeneroRepository.Cadastrar(novoGenero);
            return StatusCode(201);

        }

    }
}

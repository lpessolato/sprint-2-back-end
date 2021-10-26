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
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _FilmeRepository { get; set; }

        public FilmesController()
        {
            _FilmeRepository = new FilmeRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<FilmeDomain> listaFilmes = _FilmeRepository.ListarFilmes();
            return Ok(listaFilmes);
        }

    }
}

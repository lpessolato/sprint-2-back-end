using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }
        public AluguelController()
        {
            _AluguelRepository = new AlugelRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<AluguelDomain> listaAluguel = _AluguelRepository.ListarTodos();
            return Ok(listaAluguel);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _AluguelRepository.Cadastrar(novoAluguel);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Putidurl(int id, AluguelDomain aluguelAtualizado)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarporID(id);

            if (aluguelBuscado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem= "Aluguel nao encontrado",
                        erro = true
                    }

                    );

            }

            try
            {
                _AluguelRepository.AtualizarporURL(id, aluguelAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            

        }
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _AluguelRepository.Deletar(id);

            return NoContent();

        }

        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarporID(id);

            if (aluguelBuscado == null)
            {
                return NotFound("genero nao encontrado");

            }
            return Ok(aluguelBuscado);
        }


    }
}

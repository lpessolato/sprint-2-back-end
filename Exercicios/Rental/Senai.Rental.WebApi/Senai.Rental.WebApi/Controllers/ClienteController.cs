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
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }
        public ClienteController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaCliente = _ClienteRepository.ListarTodos();
            return Ok(listaCliente);


        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _ClienteRepository.Cadastar(novoCliente);
            return StatusCode(201);


        }

        [HttpPut("{id}")]
        public IActionResult Putidurl (int id, ClienteDomain clienteAtualizado)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarporId(id);

            if (clienteBuscado == null)
            {

                return NotFound(
                    new
                    {
                        mensagem = "Cliente nao encontrado",
                        erro = true

                    }



                    );

               

            }

            try
            {
                _ClienteRepository.AtualizarporURL(id, clienteAtualizado);
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
            _ClienteRepository.Deletar(id);
            return NoContent();
        }

        [HttpGet("{id}")]

        public IActionResult GetID(int id)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarporId(id);

            if (clienteBuscado == null)
            {
                return NotFound("Cliente nao encontrado");


            }
            return Ok(clienteBuscado);        }


    }
}

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
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }
        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculo = _VeiculoRepository.ListarTodos();
            return Ok(listaVeiculo);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _VeiculoRepository.Cadastrar(novoVeiculo);
            return StatusCode(201);
        }

        [HttpPut("{id}")]

        public IActionResult URL(int id, VeiculoDomain veiuculoAtualizado)
        {
            VeiculoDomain veiuculoBuscado = _VeiculoRepository.BuscarporID(id);
            if (veiuculoBuscado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Veiculo nao encontrado",
                        erro = true

                    }

                    );

            }

            try
            {

                _VeiculoRepository.AtualilzarporURL(id, veiuculoAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }


        }



        [HttpDelete("excluir/{id}")]
        public IActionResult delete(int id)
        {
            _VeiculoRepository.Deletar(id);
            return NoContent();
        }


        [HttpGet("{id}")]

        public IActionResult Getid(int id)
        {
            VeiculoDomain veiculoBuscado = _VeiculoRepository.BuscarporID(id);
            if (veiculoBuscado == null)
            {
                return NotFound("Veiculo nao encontrado");

            }

            return Ok(veiculoBuscado);
        }








    }
}

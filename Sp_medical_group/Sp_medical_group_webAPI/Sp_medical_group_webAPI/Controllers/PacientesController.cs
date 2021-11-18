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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();

        }


       [HttpGet]
       public IActionResult Listar()
        {
            List<Paciente> listarPaciente = _pacienteRepository.Listar();

            return Ok(listarPaciente);
        }


        [HttpGet("{idPaciente}")]
        public IActionResult BuscarPorId (int idPaciente)
        {
            return Ok(_pacienteRepository.BuscarPorId(idPaciente));
        }


        [HttpPost]

        public IActionResult Cadastrar(Paciente novoPaciente)
        {
            _pacienteRepository.Cadastrar(novoPaciente);
            return StatusCode(201);
        }

        [HttpPut("{idPaciente}")]

        public IActionResult Atualizar (int idPaciente, Paciente pacienteAtualizado)
        {
            _pacienteRepository.Atualizar(idPaciente, pacienteAtualizado);
            return StatusCode(204);
        }

        [HttpDelete("excluir/{idPaciente}")]
        public IActionResult Deletar (int idPaciente)
        {
            _pacienteRepository.Deletar(idPaciente);
            return StatusCode(204);
        }

    }
}

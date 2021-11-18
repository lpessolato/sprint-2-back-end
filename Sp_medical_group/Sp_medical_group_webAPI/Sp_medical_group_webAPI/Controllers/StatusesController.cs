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
    public class StatusesController : ControllerBase
    {
        private IStatusRepository _statusRepository { get; set; }

        public StatusesController()
        {
            _statusRepository = new StatusRepository();

        }

        [HttpGet]

        public IActionResult Listar()
        {
            List<Status> listaStatus = _statusRepository.Listar();

            return Ok(listaStatus);
        }

        [HttpGet("{idStatus}")]
        public IActionResult BuscarPorId(int idStatus)
        {
            return Ok(_statusRepository.BuscarPorId(idStatus));
        }

        [HttpPost]

        public IActionResult Cadasrar(Status novoStatus)
        {
            _statusRepository.Cadastrar(novoStatus);

            return StatusCode(201);
        }

    }
}

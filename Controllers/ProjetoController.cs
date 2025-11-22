using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository
        _projetoRepository;
        public ProjetosController(ProjetoRepository
        projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_projetoRepository.Listar());
        }


        [HttpPost]
        public IActionResult Criar(Projeto projeto)
        {
            return Ok(_projetoRepository.Criar(projeto));
        }

        [HttpPut]
        public IActionResult Editar(Projeto projeto)
        {
            return Ok(_projetoRepository.Editar(projeto));
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            return Ok(_projetoRepository.Remover(id));
        }
    }
}

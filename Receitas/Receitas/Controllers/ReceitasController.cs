using Microsoft.AspNetCore.Mvc;
using Receitas.Models;
using Receitas.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitasController(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receita>>> GetReceitas()
        {
            return Ok(await _receitaRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> GetReceita(int id)
        {
            var receita = await _receitaRepository.GetByIdAsync(id);

            if (receita == null)
            {
                return NotFound();
            }

            return Ok(receita);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReceita(Receita receita)
        {
            await _receitaRepository.AddAsync(receita);
            return CreatedAtAction(nameof(GetReceita), new { id = receita.Id }, receita);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceita(int id, Receita receita)
        {
            if (id != receita.Id)
            {
                return BadRequest();
            }

            await _receitaRepository.UpdateAsync(receita);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceita(int id)
        {
            await _receitaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
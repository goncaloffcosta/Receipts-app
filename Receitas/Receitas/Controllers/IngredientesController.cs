using Microsoft.AspNetCore.Mvc;
using Receitas.Models;
using Receitas.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly IIngredienteRepository _ingredienteRepository;

        public IngredientesController(IIngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredientes()
        {
            return Ok(await _ingredienteRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> GetIngrediente(int id)
        {
            var ingrediente = await _ingredienteRepository.GetByIdAsync(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return Ok(ingrediente);
        }

        [HttpPost]
        public async Task<ActionResult> CreateIngrediente(Ingrediente ingrediente)
        {
            await _ingredienteRepository.AddAsync(ingrediente);
            return CreatedAtAction(nameof(GetIngrediente), new { id = ingrediente.Id }, ingrediente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngrediente(int id, Ingrediente ingrediente)
        {
            if (id != ingrediente.Id)
            {
                return BadRequest();
            }

            await _ingredienteRepository.UpdateAsync(ingrediente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngrediente(int id)
        {
            await _ingredienteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
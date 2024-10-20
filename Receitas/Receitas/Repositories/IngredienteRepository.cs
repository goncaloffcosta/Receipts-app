using Microsoft.EntityFrameworkCore;
using Receitas.Data;
using Receitas.Models;
using Receitas.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receitas.Repositories
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly ReceitasContext _context;

        public IngredienteRepository(ReceitasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingrediente>> GetAllAsync()
        {
            return await _context.Ingredientes.ToListAsync();
        }

        public async Task<Ingrediente> GetByIdAsync(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null)
            {
                throw new Exception("Ingrediente não encontrado");
            }
            return ingrediente;
        }

        public async Task AddAsync(Ingrediente ingrediente)
        {
            await _context.Ingredientes.AddAsync(ingrediente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ingrediente ingrediente)
        {
            _context.Ingredientes.Update(ingrediente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente != null)
            {
                _context.Ingredientes.Remove(ingrediente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Receitas.Models;
using Receitas.Repositories;
using Receitas.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receitas.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly ReceitasContext _context;

        public ReceitaRepository(ReceitasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receita>> GetAllAsync()
        {
            return await _context.Receitas.ToListAsync();
        }

        public async Task<Receita> GetByIdAsync(int id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null)
            {
                throw new Exception("Receita não encontrada");
            }
            return receita;
        }

        public async Task AddAsync(Receita receita)
        {
            await _context.Receitas.AddAsync(receita);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Receita receita)
        {
            _context.Receitas.Update(receita);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita != null)
            {
                _context.Receitas.Remove(receita);
                await _context.SaveChangesAsync();
            }
        }
    }
}
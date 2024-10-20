using Receitas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receitas.Repositories
{
    public interface IReceitaRepository
    {
        Task<IEnumerable<Receita>> GetAllAsync();
        Task<Receita> GetByIdAsync(int id);
        Task AddAsync(Receita receita);
        Task UpdateAsync(Receita receita);
        Task DeleteAsync(int id);
    }
}

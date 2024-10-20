using Receitas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receitas.Repositories
{
    public interface IIngredienteRepository
    {
        Task<IEnumerable<Ingrediente>> GetAllAsync();
        Task<Ingrediente> GetByIdAsync(int id);
        Task AddAsync(Ingrediente ingrediente);
        Task UpdateAsync(Ingrediente ingrediente);
        Task DeleteAsync(int id);
    }
}
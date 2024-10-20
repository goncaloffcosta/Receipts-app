using System.Collections.Generic;

namespace Receitas.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Dificuldade { get; set; } = string.Empty;
        public int Duracao { get; set; }
        public ICollection<ReceitaIngrediente> Ingredientes { get; set; } = new List<ReceitaIngrediente>();
    }
}

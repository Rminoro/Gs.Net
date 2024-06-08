using System.Collections.Generic;
using Checkpoint2.Models;

namespace Checkpoint2.Repository
{
    public interface IReceitaRepository
    {
        List<Receita> ListarTodos();
        Receita ObterUm(int id);
        Receita SalvarReceita(Receita model);
        Receita EditarReceita(int id, Receita model);
        Receita ExcluirReceita(int id);
    }
}

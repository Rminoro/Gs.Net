using Checkpoint2.Models;

namespace Checkpoint2.Repository
{
    public interface ICategoriaRepository
    {
        List<Categoria> ListarTodos();
        Categoria ObterUm(int id);
        Categoria SalvarCategoria(Categoria model);
        Categoria EditarCategoria(int id, Categoria model);
        Categoria ExcluirCategoria(int id);

    }
}

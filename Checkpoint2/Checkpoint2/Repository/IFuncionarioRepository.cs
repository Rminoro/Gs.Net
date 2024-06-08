using Checkpoint2.Models;

namespace Checkpoint2.Repository
{
    public interface IFuncionarioRepository
    {
       
            List<Funcionario> ListarTodos();
            Funcionario ObterUm(int id);
            Funcionario SalvarFuncionario(Funcionario model);
            Funcionario EditarFuncionario(int id, Funcionario model);
            Funcionario ExcluirFuncionario(int id);
        
    }
}

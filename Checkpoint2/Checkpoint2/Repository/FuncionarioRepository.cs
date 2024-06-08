using Checkpoint2.Models;

namespace Checkpoint2.Repository
{
    public class FuncionarioRepository:IFuncionarioRepository
    {

        private readonly Contexto _context;

        public FuncionarioRepository(Contexto context)
        {
            _context = context;
        }
        //LISTAR TODOS
        public List<Funcionario> ListarTodos()
        {
            var listaFuncionario = _context
                .Funcionario
                .ToList()
                .OrderBy(x => x.Id)
                .ToList();
            return listaFuncionario;

        }
        //LISTAR UM
        public Funcionario ObterUm(int id)
        {
            var funcionarios = _context.Funcionario.FirstOrDefault(x => x.Id == id);
            return funcionarios;
        }


        //adicionar
        public Funcionario SalvarFuncionario(Funcionario model)
        {
            _context.Funcionario.Add(model);
            _context.SaveChanges();
            return model;
        }
        //atualizar

        public Funcionario EditarFuncionario(int id, Funcionario model)
        {
            var funcionarios = _context
                .Funcionario
                .FirstOrDefault(x => x.Id == id);

            if (funcionarios is not null)
            {
                funcionarios.Nome = model.Nome;
                funcionarios.Função = model.Função;
     

                _context.Funcionario.Update(funcionarios);
                _context.SaveChanges();
                return funcionarios;
            }
            return model;
        }

        /// excluir

        public Funcionario ExcluirFuncionario(int id)
        {
            var funcionarios = _context
                .Funcionario
                .FirstOrDefault(x => x.Id == id);

            if (funcionarios is not null)
            {
                _context.Funcionario.Remove(funcionarios);
                _context.SaveChanges();
                return funcionarios;

            }
            return new Funcionario();
        }
    }
}

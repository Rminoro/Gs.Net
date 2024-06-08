using Checkpoint2.Models;

namespace Checkpoint2.Repository
{
    public class ReceitaRepository: IReceitaRepository
    {
        private readonly Contexto _context;

        public ReceitaRepository(Contexto context)
        {
            _context = context;
        }
        //LISTAR TODOS
        public List<Receita> ListarTodos()
        {
            var listaReceita = _context
                .Receita
                .ToList()
                .OrderBy(x => x.Id)
                .ToList();
            return listaReceita;

        }
        //LISTAR UM
        public Receita ObterUm(int id)
        {
            var receitas = _context.Receita.FirstOrDefault(x => x.Id == id);
            return receitas;
        }

        //adicionar
        public Receita SalvarReceita(Receita model)
        {
            _context.Receita.Add(model);
            _context.SaveChanges();
            return model;
        }

        //atualizar

        public Receita EditarReceita(int id, Receita model)
        {
            var receitas = _context
                .Receita
                .FirstOrDefault(x => x.Id == id);

            if (receitas is not null)
            {
                receitas.Nome = model.Nome;
                receitas.Ingredientes = model.Ingredientes;
                receitas.ModoPreparo = model.ModoPreparo;

                _context.Receita.Update(receitas);
                _context.SaveChanges();
                return receitas;
            }
            return model;
        }

        /// excluir

        public Receita ExcluirReceita(int id)
        {
            var receitas = _context
                .Receita
                .FirstOrDefault(x => x.Id == id);

            if (receitas is not null)
            {
                _context.Receita.Remove(receitas);
                _context.SaveChanges();
                return receitas;

            }
            return new Receita();
        }
    }
}

using AspNetCore;
using Checkpoint2.Models;

namespace Checkpoint2.Repository
{
    public class CategoriaRepository:ICategoriaRepository
    {
        private readonly Contexto _context;
        
        public CategoriaRepository(Contexto context)
        {
            _context = context;
        }
        //LISTAR TODOS
        public List<Categoria> ListarTodos()
        {
            var listaCategorias = _context
                .Categoria
                .ToList()
                .OrderBy(x => x.Id)
                .ToList();
            return listaCategorias; 
            
        }

        //LISTAR UM
        public Categoria ObterUm(int id)
        {
            var categorias = _context.Categoria.FirstOrDefault(x => x.Id == id);
            return categorias;
        }

        //adicionar
        public Categoria SalvarCategoria(Categoria model)
        {
            _context.Categoria.Add(model);
            _context.SaveChanges();
            return model;
        }

        //atualizar

        public Categoria EditarCategoria (int id, Categoria model)
        {
            var categorias = _context
                .Categoria
                .FirstOrDefault(x => x.Id == id);

            if(categorias is not null)
            {
                categorias.Nome = model.Nome;
                categorias.Descricao = model.Descricao; 

                _context.Categoria.Update(categorias);
                _context.SaveChanges ();
                return categorias;
            }
            return model;
        }
        
        /// excluir
        
        public Categoria ExcluirCategoria(int id)
        {
            var categorias = _context
                .Categoria
                .FirstOrDefault( x => x.Id == id);

            if (categorias is not null)
            {
                _context.Categoria.Remove(categorias);
                _context.SaveChanges(); 
                return categorias;

            }
            return new Categoria();
        }

    }
}

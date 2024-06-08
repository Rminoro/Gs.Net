using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Checkpoint2.Models;
using Checkpoint2.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace Checkpoint2.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // GET: Categorias
        public IActionResult Index()
        {
            var categorias = _categoriaRepository
                .ListarTodos();
            return View(categorias);    
        }

      //obter um
        
        public IActionResult Details(int id)
        {
            var categoria = _categoriaRepository
                .ObterUm(id);
            return View(categoria); 
        }

        // adicionar
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
 
        public IActionResult Create(Categoria model)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository
                    .SalvarCategoria(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        

        //editar
        public IActionResult Edit (int id)
        {
            if (id == null)
            { return NotFound(); }

            var categorias = _categoriaRepository.ObterUm(id);
            return View(categorias);
        }
        [HttpPost]
        public IActionResult Edit (int id, Categoria model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;

                _categoriaRepository.EditarCategoria(id, model);

                return RedirectToAction("Index");   
            }
            return View(model);
        }

        //Excluir
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _categoriaRepository.ObterUm(id.Value);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }
        [HttpPost]
       public IActionResult Delete(int id)
        {
            _categoriaRepository.ExcluirCategoria(id);
            return RedirectToAction("Index");
        }

    }
}

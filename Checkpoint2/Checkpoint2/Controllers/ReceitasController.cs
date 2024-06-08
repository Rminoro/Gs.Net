using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Checkpoint2.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client;
using Checkpoint2.Repository;

namespace Checkpoint2.Controllers
{

    public class ReceitasController : Controller
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitasController(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }
        // GET: Funcionarios
        public IActionResult Index()
        {
            var receitas = _receitaRepository
                .ListarTodos();
            return View(receitas);
        }

        //obter um
        public IActionResult Details(int id)
        {
            var receitas = _receitaRepository
                .ObterUm(id);
            return View(receitas);
        }

        //adicionar
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]

        public IActionResult Create(Receita model)
        {
            if (ModelState.IsValid)
            {
                _receitaRepository
                    .SalvarReceita(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //editar
        public IActionResult Edit(int id)
        {
            if (id == null)
            { return NotFound(); }

            var receitas = _receitaRepository.ObterUm(id);
            return View(receitas);
        }
        [HttpPost]
        public IActionResult Edit(int id, Receita model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;

                _receitaRepository.EditarReceita(id, model);

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

            var receitas = _receitaRepository.ObterUm(id.Value);
            if (receitas == null)
            {
                return NotFound();
            }

            return View(receitas);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _receitaRepository.ExcluirReceita(id);
            return RedirectToAction("Index");
        }


    }

}
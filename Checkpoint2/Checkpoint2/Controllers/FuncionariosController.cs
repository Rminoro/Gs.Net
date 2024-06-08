using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Checkpoint2.Models;
using Checkpoint2.Repository;

namespace Checkpoint2.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        // GET: Funcionarios
        public IActionResult Index()
        {
            var Funcionarios = _funcionarioRepository
                .ListarTodos();
            return View(Funcionarios);
        }

       //obter um
       public IActionResult Details(int id)
        {
            var funcionario = _funcionarioRepository
                .ObterUm(id);
            return View(funcionario);
        }

        //adicionar
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]

        public IActionResult Create(Funcionario model)
        {
            if (ModelState.IsValid)
            {
                _funcionarioRepository
                    .SalvarFuncionario(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        //editar
        public IActionResult Edit(int id)
        {
            if (id == null)
            { return NotFound(); }

            var funcionarios = _funcionarioRepository.ObterUm(id);
            return View(funcionarios);
        }
        [HttpPost]
        public IActionResult Edit(int id, Funcionario model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;

                _funcionarioRepository.EditarFuncionario(id, model);

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

            var funcionarios = _funcionarioRepository.ObterUm(id.Value);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _funcionarioRepository.ExcluirFuncionario(id);
            return RedirectToAction("Index");
        }


    }
}

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

namespace Checkpoint2.Controllers

{
    public class ReceitasController : Controller
    {
        private readonly Contexto _context;

        public ReceitasController(Contexto context)
        {
            _context = context;
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Receita.ToListAsync());
        }
        public IActionResult ListarReceitas()
        {
            //Select * from tb_receita
            var receitas = _context.Receita.ToList();
            return Json(receitas);
        }


        // GET: Receitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        public IActionResult ListarUm()
        {
            var receita = _context.Receita.Find(2);
            return Json(receita);
        }

        // GET: Receitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ingredientes,ModoPreparo")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receita);
        }

        ////////////////////////////////////////////////////////////////// PROFESSOR
        ///
        public IActionResult Inserir()
        {
            var model = new Receita
            {
                Id = 10,
                Nome = "Bolo",
                Ingredientes = "Farinha e ovo",
                ModoPreparo = "Bate tudo e assa",
            };
            _context.Receita.Add(model);
            _context.SaveChanges();
            return Json(new { });
        }


            ////////////////////////////Altera professor
        public IActionResult Alterar()
        {
            var receita = _context.Receita.Find(2); 

            receita.Nome = "Bolo de milho";
            _context.Receita.Update(receita);
            _context.SaveChanges();
            return Json(receita);

        }

        ////////delete Professor
        public IActionResult Deletar()
        {
            var receita = _context.Receita.Find(2);

            _context.Receita.Remove(receita);
            _context.SaveChanges();

            return Json(receita);   
        }


                /// <summary>
        //
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Ingredientes,ModoPreparo")] Receita receita)
        {
            if (id != receita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receita.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(receita);
        }

        // GET: Receitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receita = await _context.Receita.FindAsync(id);
            if (receita != null)
            {
                _context.Receita.Remove(receita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(int id)
        {
            return _context.Receita.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWork.Models;

namespace MyWork.Controllers
{
    public class FuncionárioController : Controller
    {
        private readonly FuncionarioContext _context;

        public FuncionárioController(FuncionarioContext context)
        {
            _context = context;
        }

        // GET: Funcionário
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionário.ToListAsync());
        }

        // GET: Funcionário/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionário = await _context.Funcionário
                .FirstOrDefaultAsync(m => m.IDFuncionarios == id);
            if (funcionário == null)
            {
                return NotFound();
            }

            return View(funcionário);
        }

        // GET: Funcionário/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionário/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFuncionarios,Nome,Numero")] Funcionário funcionário)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionário);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionário);
        }

        // GET: Funcionário/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionário = await _context.Funcionário.FindAsync(id);
            if (funcionário == null)
            {
                return NotFound();
            }
            return View(funcionário);
        }

        // POST: Funcionário/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDFuncionarios,Nome,Numero")] Funcionário funcionário)
        {
            if (id != funcionário.IDFuncionarios)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionário);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionárioExists(funcionário.IDFuncionarios))
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
            return View(funcionário);
        }

        // GET: Funcionário/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionário = await _context.Funcionário
                .FirstOrDefaultAsync(m => m.IDFuncionarios == id);
            if (funcionário == null)
            {
                return NotFound();
            }

            return View(funcionário);
        }

        // POST: Funcionário/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionário = await _context.Funcionário.FindAsync(id);
            _context.Funcionário.Remove(funcionário);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionárioExists(int id)
        {
            return _context.Funcionário.Any(e => e.IDFuncionarios == id);
        }
    }
}

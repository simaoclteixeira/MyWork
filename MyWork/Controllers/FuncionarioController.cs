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
    public class FuncionarioController : Controller
    {
        private readonly GestaoServicoContext _context;
        public int PaginasTamanho = 5;

        public FuncionarioController(GestaoServicoContext context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index(int page = 1)
        {
            decimal nuDepartamento = _context.Funcionario.Count();
            int NUMERO_PAGINAS_ANTES_DEPOIS = ((int)nuDepartamento / PaginasTamanho);

            if (nuDepartamento % PaginasTamanho == 0)
            {
                NUMERO_PAGINAS_ANTES_DEPOIS -= 1;
            }

            PaginacaoFuncionario dp = new PaginacaoFuncionario
            {
                Funcionario = _context.Funcionario.OrderBy(p => p.Nome).Skip((page - 1) * PaginasTamanho).Take(PaginasTamanho),
                PagAtual = page,
                PriPagina = Math.Max(1, page - NUMERO_PAGINAS_ANTES_DEPOIS),
                TotPaginas = (int)Math.Ceiling(nuDepartamento / PaginasTamanho)
            };

            dp.UltPagina = Math.Min(dp.TotPaginas, page + NUMERO_PAGINAS_ANTES_DEPOIS);

            return View(dp);
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.FuncionariosID == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionariosID,Nome,Numero,Email")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionariosID,Nome,Numero,Email")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionariosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionariosID))
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
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.FuncionariosID == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.FuncionariosID == id);
        }
    }
}

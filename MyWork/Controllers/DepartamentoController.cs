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
    public class DepartamentoController : Controller
    {
        private readonly GestaoServicoContext _context;
        public int PaginasTamanho = 5;
        private int NUMBER_FUNC_PER_PAGE = 5;

        public DepartamentoController(GestaoServicoContext context)
        {
            _context = context;
        }

        // GET: Departamento

        public async Task<IActionResult> Index(int page = 1, string searchString = "", string sort = "true", string procurar = "Nome")

        {

            var departamentos = from p in _context.Departamentos
                                select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                departamentos = departamentos.Where(p => p.Nome.Contains(searchString));
                if (procurar.Equals("Nome"))
                {
                    departamentos = departamentos.Where(p => p.Nome.Contains(searchString));
                }
            }

            decimal nuDepartamento = _context.Departamentos.Count();
            int NUMERO_PAGINAS_ANTES_DEPOIS = ((int)nuDepartamento / PaginasTamanho);

            if (nuDepartamento % PaginasTamanho == 0)
            {
                NUMERO_PAGINAS_ANTES_DEPOIS -= 1;
            }

            PaginacaoDepartamentos dp = new PaginacaoDepartamentos
            {
                Sort = sort,
                Departamento = _context.Departamentos.OrderBy(p => p.Nome).Skip((page - 1) * PaginasTamanho).Take(PaginasTamanho),
                PagAtual = page,
                PriPagina = Math.Max(1, page - NUMERO_PAGINAS_ANTES_DEPOIS),
                TotPaginas = (int)Math.Ceiling(nuDepartamento / PaginasTamanho),
                Procurar = procurar
            };

            if (sort.Equals("true"))
            {
                dp.Departamento = departamentos.OrderBy(p => p.Nome).Skip((page - 1) * NUMBER_FUNC_PER_PAGE).Take(NUMBER_FUNC_PER_PAGE);
            }
            else
            {
                dp.Departamento = departamentos.OrderByDescending(p => p.Nome).Skip((page - 1) * NUMBER_FUNC_PER_PAGE).Take(NUMBER_FUNC_PER_PAGE);
            }
            dp.UltPagina = Math.Min(dp.TotPaginas, page + NUMERO_PAGINAS_ANTES_DEPOIS);
            dp.StringProcurar = searchString;

            return View(dp);
        
    }

        // GET: Departamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentos = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.DepartamentoID == id);
            if (departamentos == null)
            {
                return NotFound();
            }

            return View(departamentos);
        }

        // GET: Departamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartamentoID,Nome")] Departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamentos);
        }

        // GET: Departamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentos = await _context.Departamentos.FindAsync(id);
            if (departamentos == null)
            {
                return NotFound();
            }
            return View(departamentos);
        }

        // POST: Departamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartamentoID,Nome")] Departamentos departamentos)
        {
            if (id != departamentos.DepartamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentosExists(departamentos.DepartamentoID))
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
            return View(departamentos);
        }

        // GET: Departamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentos = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.DepartamentoID == id);
            if (departamentos == null)
            {
                return NotFound();
            }

            return View(departamentos);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamentos = await _context.Departamentos.FindAsync(id);
            _context.Departamentos.Remove(departamentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentosExists(int id)
        {
            return _context.Departamentos.Any(e => e.DepartamentoID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Arifarma.Models;

namespace Arifarma.Controllers
{
    public class CompraMedicamentoesController : Controller
    {
        private readonly drogueria_arifarmaContext _context;

        public CompraMedicamentoesController(drogueria_arifarmaContext context)
        {
            _context = context;
        }

        // GET: CompraMedicamentoes
        public async Task<IActionResult> Index()
        {
            var drogueria_arifarmaContext = _context.CompraMedicamentos.Include(c => c.CodProveedorNavigation);
            return View(await drogueria_arifarmaContext.ToListAsync());
        }

        // GET: CompraMedicamentoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CompraMedicamentos == null)
            {
                return NotFound();
            }

            var compraMedicamento = await _context.CompraMedicamentos
                .Include(c => c.CodProveedorNavigation)
                .FirstOrDefaultAsync(m => m.CodCompraMedicamentos == id);
            if (compraMedicamento == null)
            {
                return NotFound();
            }

            return View(compraMedicamento);
        }

        // GET: CompraMedicamentoes/Create
        public IActionResult Create()
        {
            ViewData["CodProveedor"] = new SelectList(_context.Proveedors, "CodProveedor", "CodProveedor");
            return View();
        }

        // POST: CompraMedicamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCompraMedicamentos,CodProveedor,Fecha,ValorCompra")] CompraMedicamento compraMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compraMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodProveedor"] = new SelectList(_context.Proveedors, "CodProveedor", "CodProveedor", compraMedicamento.CodProveedor);
            return View(compraMedicamento);
        }

        // GET: CompraMedicamentoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CompraMedicamentos == null)
            {
                return NotFound();
            }

            var compraMedicamento = await _context.CompraMedicamentos.FindAsync(id);
            if (compraMedicamento == null)
            {
                return NotFound();
            }
            ViewData["CodProveedor"] = new SelectList(_context.Proveedors, "CodProveedor", "CodProveedor", compraMedicamento.CodProveedor);
            return View(compraMedicamento);
        }

        // POST: CompraMedicamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodCompraMedicamentos,CodProveedor,Fecha,ValorCompra")] CompraMedicamento compraMedicamento)
        {
            if (id != compraMedicamento.CodCompraMedicamentos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraMedicamentoExists(compraMedicamento.CodCompraMedicamentos))
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
            ViewData["CodProveedor"] = new SelectList(_context.Proveedors, "CodProveedor", "CodProveedor", compraMedicamento.CodProveedor);
            return View(compraMedicamento);
        }

        // GET: CompraMedicamentoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CompraMedicamentos == null)
            {
                return NotFound();
            }

            var compraMedicamento = await _context.CompraMedicamentos
                .Include(c => c.CodProveedorNavigation)
                .FirstOrDefaultAsync(m => m.CodCompraMedicamentos == id);
            if (compraMedicamento == null)
            {
                return NotFound();
            }

            return View(compraMedicamento);
        }

        // POST: CompraMedicamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CompraMedicamentos == null)
            {
                return Problem("Entity set 'drogueria_arifarmaContext.CompraMedicamentos'  is null.");
            }
            var compraMedicamento = await _context.CompraMedicamentos.FindAsync(id);
            if (compraMedicamento != null)
            {
                _context.CompraMedicamentos.Remove(compraMedicamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraMedicamentoExists(string id)
        {
          return (_context.CompraMedicamentos?.Any(e => e.CodCompraMedicamentos == id)).GetValueOrDefault();
        }
    }
}

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
    public class DetalleCompraMedicamenController : Controller
    {
        private readonly drogueria_arifarmaContext _context;

        public DetalleCompraMedicamenController(drogueria_arifarmaContext context)
        {
            _context = context;
        }

        // GET: DetalleCompraMedicamen
        public async Task<IActionResult> Index()
        {
            var drogueria_arifarmaContext = _context.DetalleCompraMedicamen.Include(d => d.CodCompraMedicamentosNavigation).Include(d => d.CodProductoNavigation);
            return View(await drogueria_arifarmaContext.ToListAsync());
        }

        // GET: DetalleCompraMedicamen/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DetalleCompraMedicamen == null)
            {
                return NotFound();
            }

            var detalleCompraMedicaman = await _context.DetalleCompraMedicamen
                .Include(d => d.CodCompraMedicamentosNavigation)
                .Include(d => d.CodProductoNavigation)
                .FirstOrDefaultAsync(m => m.CodDetalleCompraMedicamentos == id);
            if (detalleCompraMedicaman == null)
            {
                return NotFound();
            }

            return View(detalleCompraMedicaman);
        }

        // GET: DetalleCompraMedicamen/Create
        public IActionResult Create()
        {
            ViewData["CodCompraMedicamentos"] = new SelectList(_context.CompraMedicamentos, "CodCompraMedicamentos", "CodCompraMedicamentos");
            ViewData["CodProducto"] = new SelectList(_context.Productos, "CodProducto", "CodProducto");
            return View();
        }

        // POST: DetalleCompraMedicamen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodDetalleCompraMedicamentos,CodProducto,CodCompraMedicamentos,Cantidad,Precio")] DetalleCompraMedicaman detalleCompraMedicaman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCompraMedicaman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodCompraMedicamentos"] = new SelectList(_context.CompraMedicamentos, "CodCompraMedicamentos", "CodCompraMedicamentos", detalleCompraMedicaman.CodCompraMedicamentos);
            ViewData["CodProducto"] = new SelectList(_context.Productos, "CodProducto", "CodProducto", detalleCompraMedicaman.CodProducto);
            return View(detalleCompraMedicaman);
        }

        // GET: DetalleCompraMedicamen/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DetalleCompraMedicamen == null)
            {
                return NotFound();
            }

            var detalleCompraMedicaman = await _context.DetalleCompraMedicamen.FindAsync(id);
            if (detalleCompraMedicaman == null)
            {
                return NotFound();
            }
            ViewData["CodCompraMedicamentos"] = new SelectList(_context.CompraMedicamentos, "CodCompraMedicamentos", "CodCompraMedicamentos", detalleCompraMedicaman.CodCompraMedicamentos);
            ViewData["CodProducto"] = new SelectList(_context.Productos, "CodProducto", "CodProducto", detalleCompraMedicaman.CodProducto);
            return View(detalleCompraMedicaman);
        }

        // POST: DetalleCompraMedicamen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodDetalleCompraMedicamentos,CodProducto,CodCompraMedicamentos,Cantidad,Precio")] DetalleCompraMedicaman detalleCompraMedicaman)
        {
            if (id != detalleCompraMedicaman.CodDetalleCompraMedicamentos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCompraMedicaman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCompraMedicamanExists(detalleCompraMedicaman.CodDetalleCompraMedicamentos))
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
            ViewData["CodCompraMedicamentos"] = new SelectList(_context.CompraMedicamentos, "CodCompraMedicamentos", "CodCompraMedicamentos", detalleCompraMedicaman.CodCompraMedicamentos);
            ViewData["CodProducto"] = new SelectList(_context.Productos, "CodProducto", "CodProducto", detalleCompraMedicaman.CodProducto);
            return View(detalleCompraMedicaman);
        }

        // GET: DetalleCompraMedicamen/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DetalleCompraMedicamen == null)
            {
                return NotFound();
            }

            var detalleCompraMedicaman = await _context.DetalleCompraMedicamen
                .Include(d => d.CodCompraMedicamentosNavigation)
                .Include(d => d.CodProductoNavigation)
                .FirstOrDefaultAsync(m => m.CodDetalleCompraMedicamentos == id);
            if (detalleCompraMedicaman == null)
            {
                return NotFound();
            }

            return View(detalleCompraMedicaman);
        }

        // POST: DetalleCompraMedicamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DetalleCompraMedicamen == null)
            {
                return Problem("Entity set 'drogueria_arifarmaContext.DetalleCompraMedicamen'  is null.");
            }
            var detalleCompraMedicaman = await _context.DetalleCompraMedicamen.FindAsync(id);
            if (detalleCompraMedicaman != null)
            {
                _context.DetalleCompraMedicamen.Remove(detalleCompraMedicaman);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCompraMedicamanExists(string id)
        {
          return (_context.DetalleCompraMedicamen?.Any(e => e.CodDetalleCompraMedicamentos == id)).GetValueOrDefault();
        }
    }
}

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
    public class DetalleFactsController : Controller
    {
        private readonly drogueria_arifarmaContext _context;

        public DetalleFactsController(drogueria_arifarmaContext context)
        {
            _context = context;
        }

        // GET: DetalleFacts
        public async Task<IActionResult> Index()
        {
            var drogueria_arifarmaContext = _context.DetalleFacts.Include(d => d.CodFacturaNavigation).Include(d => d.CodProductoNavigation);
            return View(await drogueria_arifarmaContext.ToListAsync());
        }

        // GET: DetalleFacts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DetalleFacts == null)
            {
                return NotFound();
            }

            var detalleFact = await _context.DetalleFacts
                .Include(d => d.CodFacturaNavigation)
                .Include(d => d.CodProductoNavigation)
                .FirstOrDefaultAsync(m => m.CodDetalleFactura == id);
            if (detalleFact == null)
            {
                return NotFound();
            }

            return View(detalleFact);
        }

        // GET: DetalleFacts/Create
        public IActionResult Create()
        {
            ViewData["CodFactura"] = new SelectList(_context.Facturas, "CodFactura", "CodFactura");
            ViewData["CodProducto"] = new SelectList(_context.Productos, "CodProducto", "CodProducto");
            return View();
        }

        // POST: DetalleFacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodDetalleFactura,CodFactura,CodProducto,Cantidad,SubtotalVenta")] DetalleFact detalleFact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodFactura"] = new SelectList(_context.Facturas, "CodFactura", "CodFactura", detalleFact.CodFactura);
            ViewData["CodProducto"] = new SelectList(_context.Productos, "CodProducto", "CodProducto", detalleFact.CodProducto);
            return View(detalleFact);
        }

        // GET: DetalleFacts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DetalleFacts == null)
            {
                return NotFound();
            }

            var detalleFact = await _context.DetalleFacts.FindAsync(id);
            if (detalleFact == null)
            {
                return NotFound();
            }
            ViewData["CodFactura"] = new SelectList(_context.Facturas, "CodFactura", "CodFactura", detalleFact.CodFactura);
            ViewData["CodProducto"] = new SelectList(_context.Productos, "CodProducto", "CodProducto", detalleFact.CodProducto);
            return View(detalleFact);
        }

        // POST: DetalleFacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodDetalleFactura,CodFactura,CodProducto,Cantidad,SubtotalVenta")] DetalleFact detalleFact)
        {
            if (id != detalleFact.CodDetalleFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFactExists(detalleFact.CodDetalleFactura))
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
            ViewData["CodFactura"] = new SelectList(_context.Facturas, "CodFactura", "CodFactura", detalleFact.CodFactura);
            ViewData["CodProducto"] = new SelectList(_context.Productos, "CodProducto", "CodProducto", detalleFact.CodProducto);
            return View(detalleFact);
        }

        // GET: DetalleFacts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DetalleFacts == null)
            {
                return NotFound();
            }

            var detalleFact = await _context.DetalleFacts
                .Include(d => d.CodFacturaNavigation)
                .Include(d => d.CodProductoNavigation)
                .FirstOrDefaultAsync(m => m.CodDetalleFactura == id);
            if (detalleFact == null)
            {
                return NotFound();
            }

            return View(detalleFact);
        }

        // POST: DetalleFacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DetalleFacts == null)
            {
                return Problem("Entity set 'drogueria_arifarmaContext.DetalleFacts'  is null.");
            }
            var detalleFact = await _context.DetalleFacts.FindAsync(id);
            if (detalleFact != null)
            {
                _context.DetalleFacts.Remove(detalleFact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFactExists(string id)
        {
          return (_context.DetalleFacts?.Any(e => e.CodDetalleFactura == id)).GetValueOrDefault();
        }
    }
}

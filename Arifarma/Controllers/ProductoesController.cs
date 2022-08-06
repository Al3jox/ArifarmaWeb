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
    public class ProductoesController : Controller
    {
        private readonly drogueria_arifarmaContext _context;

        public ProductoesController(drogueria_arifarmaContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            var drogueria_arifarmaContext = _context.Productos.Include(p => p.CodCategoriaNavigation);
            return View(await drogueria_arifarmaContext.ToListAsync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.CodCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.CodProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["CodCategoria"] = new SelectList(_context.Categoria, "CodCategoria", "CodCategoria");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodProducto,CodCategoria,Nombre,PrecioCompra,PrecioVenta,FechaVencimiento,Impuesto")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodCategoria"] = new SelectList(_context.Categoria, "CodCategoria", "CodCategoria", producto.CodCategoria);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["CodCategoria"] = new SelectList(_context.Categoria, "CodCategoria", "CodCategoria", producto.CodCategoria);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodProducto,CodCategoria,Nombre,PrecioCompra,PrecioVenta,FechaVencimiento,Impuesto")] Producto producto)
        {
            if (id != producto.CodProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.CodProducto))
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
            ViewData["CodCategoria"] = new SelectList(_context.Categoria, "CodCategoria", "CodCategoria", producto.CodCategoria);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.CodCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.CodProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'drogueria_arifarmaContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(string id)
        {
          return (_context.Productos?.Any(e => e.CodProducto == id)).GetValueOrDefault();
        }
    }
}

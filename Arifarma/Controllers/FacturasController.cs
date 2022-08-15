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
    public class FacturasController : Controller
    {
        private readonly drogueria_arifarmaContext _context;

        public FacturasController(drogueria_arifarmaContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var drogueria_arifarmaContext = _context.Facturas.Include(f => f.CodClienteNavigation).Include(f => f.CodEmpleadoNavigation);
            return View(await drogueria_arifarmaContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.CodClienteNavigation)
                .Include(f => f.CodEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.CodFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["CodCliente"] = new SelectList(_context.Clientes, "CodCliente", "CodCliente");
            ViewData["CodEmpleado"] = new SelectList(_context.Empleados, "CodEmpleado", "CodEmpleado");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodFactura,CodCliente,CodEmpleado,Fecha,Cantidad,CostoTotal")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodCliente"] = new SelectList(_context.Clientes, "CodCliente", "CodCliente", factura.CodCliente);
            ViewData["CodEmpleado"] = new SelectList(_context.Empleados, "CodEmpleado", "CodEmpleado", factura.CodEmpleado);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["CodCliente"] = new SelectList(_context.Clientes, "CodCliente", "CodCliente", factura.CodCliente);
            ViewData["CodEmpleado"] = new SelectList(_context.Empleados, "CodEmpleado", "CodEmpleado", factura.CodEmpleado);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodFactura,CodCliente,CodEmpleado,Fecha,Cantidad,CostoTotal")] Factura factura)
        {
            if (id != factura.CodFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.CodFactura))
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
            ViewData["CodCliente"] = new SelectList(_context.Clientes, "CodCliente", "CodCliente", factura.CodCliente);
            ViewData["CodEmpleado"] = new SelectList(_context.Empleados, "CodEmpleado", "CodEmpleado", factura.CodEmpleado);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.CodClienteNavigation)
                .Include(f => f.CodEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.CodFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Facturas == null)
            {
                return Problem("Entity set 'drogueria_arifarmaContext.Facturas'  is null.");
            }
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(string id)
        {
          return (_context.Facturas?.Any(e => e.CodFactura == id)).GetValueOrDefault();
        }
    }
}

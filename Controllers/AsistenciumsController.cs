using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARTF_ASISTENCIA_v2.Models;

namespace ARTF_ASISTENCIA_v2.Controllers
{
    public class AsistenciumsController : Controller
    {
        private readonly BaseasistenciaContext _context;

        public AsistenciumsController(BaseasistenciaContext context)
        {
            _context = context;
        }

        // GET: Asistenciums
        public async Task<IActionResult> Index()
        {
              return _context.Asistencia != null ? 
                          View(await _context.Asistencia.ToListAsync()) :
                          Problem("Entity set 'BaseasistenciaContext.Asistencia'  is null.");
        }

        // GET: Asistenciums/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null || _context.Asistencia == null)
            {
                return NotFound();
            }

            var asistencium = await _context.Asistencia
                .FirstOrDefaultAsync(m => m.DiaReg == id);
            if (asistencium == null)
            {
                return NotFound();
            }

            return View(asistencium);
        }

        // GET: Asistenciums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asistenciums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiaReg,HrfhIng,HrfhSal,Observaciones,Justificaciones,Numemp")] Asistencium asistencium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistencium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asistencium);
        }

        // GET: Asistenciums/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null || _context.Asistencia == null)
            {
                return NotFound();
            }

            var asistencium = await _context.Asistencia.FindAsync(id);
            if (asistencium == null)
            {
                return NotFound();
            }
            return View(asistencium);
        }

        // POST: Asistenciums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("DiaReg,HrfhIng,HrfhSal,Observaciones,Justificaciones,Numemp")] Asistencium asistencium)
        {
            if (id != asistencium.DiaReg)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistencium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciumExists(asistencium.DiaReg))
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
            return View(asistencium);
        }

        // GET: Asistenciums/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null || _context.Asistencia == null)
            {
                return NotFound();
            }

            var asistencium = await _context.Asistencia
                .FirstOrDefaultAsync(m => m.DiaReg == id);
            if (asistencium == null)
            {
                return NotFound();
            }

            return View(asistencium);
        }

        // POST: Asistenciums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            if (_context.Asistencia == null)
            {
                return Problem("Entity set 'BaseasistenciaContext.Asistencia'  is null.");
            }
            var asistencium = await _context.Asistencia.FindAsync(id);
            if (asistencium != null)
            {
                _context.Asistencia.Remove(asistencium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciumExists(DateTime id)
        {
          return (_context.Asistencia?.Any(e => e.DiaReg == id)).GetValueOrDefault();
        }
    }
}

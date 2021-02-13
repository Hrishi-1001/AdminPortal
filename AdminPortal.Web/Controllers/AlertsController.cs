using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPortal.Web.Data;
using AdminPortal.Web.Models;

namespace AdminPortal.Web.Views.Alerts
{
    public class AlertsController : Controller
    {
        private readonly DatabaseContext _context;

        public AlertsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Alerts
        [Route("/Alerts")]
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Alerts.Include(a => a.Asset);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Alerts/Details/5
        [Route("/Alerts/Details/id")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alerts
                .Include(a => a.Asset)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alert == null)
            {
                return NotFound();
            }

            return View(alert);
        }

        // GET: Alerts/Create
        [Route("/Alerts/Create")]
        public IActionResult Create()
        {
            ViewData["AssetID"] = new SelectList(_context.Assets, "Id", "Id");
            return View();
        }

        // POST: Alerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/Alerts/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Text,AssetID")] Alert alert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetID"] = new SelectList(_context.Assets, "Id", "Id", alert.AssetID);
            return View(alert);
        }

        // GET: Alerts/Edit/5
        [Route("/Alerts/Edit/id")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null)
            {
                return NotFound();
            }
            ViewData["AssetID"] = new SelectList(_context.Assets, "Id", "Id", alert.AssetID);
            return View(alert);
        }

        // POST: Alerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/Alerts/Edit/id")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Text,AssetID")] Alert alert)
        {
            if (id != alert.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertExists(alert.ID))
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
            ViewData["AssetID"] = new SelectList(_context.Assets, "Id", "Id", alert.AssetID);
            return View(alert);
        }

        // GET: Alerts/Delete/5
        [Route("/Alerts/Delete/id")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alerts
                .Include(a => a.Asset)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alert == null)
            {
                return NotFound();
            }

            return View(alert);
        }

        // POST: Alerts/Delete/5
        [HttpPost]
        [Route("/Alerts/Delete/id")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlertExists(int id)
        {
            return _context.Alerts.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacrementPlanner.Models;
using SacrementPlanner.ViewModels;

namespace SacrementPlanner.Views.Bulletins
{
    public class BulletinsController : Controller
    {
        private readonly BulletinContext _context;

        public BulletinsController(BulletinContext context)
        {
            _context = context;
        }

        // GET: Bulletins
        [HttpGet]
        public async Task<IActionResult> Index(int? ID)
        {
            var viewModel = new IndexData();
            viewModel.Planners = await _context.Planner.Include(p => p.Bishopric).ToListAsync();

            if (ID != null)
            {
                viewModel.Speakers = await _context.Speakers.Include(x => x.Planner).Where(i => i.PlannerId == ID.Value).ToListAsync();
            }

            return View(viewModel);
        }

        // GET: Bulletins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner
                .Include(p => p.Bishopric)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (planner == null)
            {
                return NotFound();
            }

            return View(planner);
        }

        // GET: Bulletins/Create
        [HttpGet]
        public IActionResult Create()
        {
            var bishopricData = _context.Bishoprics.Where(b => b.Active == true);
            ViewData["BishopricId"] = new SelectList(bishopricData, "ID", "Name");
            return View();
        }

        // POST: Bulletins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OpeningSong,SacramentSong,IntermediateSong,ClosingSong,SacramentDate,BishopricId")] Planner planner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BishopricId"] = new SelectList(_context.Bishoprics, "ID", "Name");
            return View(planner);
        }

        // GET: Bulletins/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner.FindAsync(id);
            if (planner == null)
            {
                return NotFound();
            }
            ViewData["BishopricId"] = new SelectList(_context.Bishoprics, "ID", "Name", planner.BishopricId);
            return View(planner);
        }

        // POST: Bulletins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OpeningSong,SacramentSong,IntermediateSong,ClosingSong,SacramentDate,BishopricId")] Planner planner)
        {
            if (id != planner.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlannerExists(planner.ID))
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
            ViewData["BishopricId"] = new SelectList(_context.Bishoprics, "ID", "Name", planner.BishopricId);
            return View(planner);
        }

        // GET: Bulletins/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner
                .Include(p => p.Bishopric)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (planner == null)
            {
                return NotFound();
            }

            return View(planner);
        }

        // POST: Bulletins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planner = await _context.Planner.FindAsync(id);
            _context.Planner.Remove(planner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlannerExists(int id)
        {
            return _context.Planner.Any(e => e.ID == id);
        }
    }
}

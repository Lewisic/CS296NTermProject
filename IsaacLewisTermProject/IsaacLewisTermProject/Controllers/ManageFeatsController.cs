using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsaacLewisTermProject.Data;
using IsaacLewisTermProject.Models;
using IsaacLewisTermProject.Repos;
using Microsoft.AspNetCore.Identity;

namespace IsaacLewisTermProject.Controllers
{
    public class ManageFeatsController : Controller
    {
        UserManager<AppUser> userManager;

        IHomebrewRepository _context;

        public ManageFeatsController(IHomebrewRepository repo, UserManager<AppUser> userMngr)
        {
            _context = repo;
            userManager = userMngr;
        }

        // GET: ManageFeats
        public async Task<IActionResult> Index()
        {
              return _context.Feats != null ? 
                          View(await _context.Feats.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Feats'  is null.");
        }

        // GET: ManageFeats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Feats == null)
            {
                return NotFound();
            }

            var feat = await _context.Feats
                .FirstOrDefaultAsync(m => m.FeatId == id);
            if (feat == null)
            {
                return NotFound();
            }

            return View(feat);
        }

        // GET: ManageFeats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageFeats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeatId,FeatName,FeatEffect,DateAdded")] Feat feat)
        {
            if (ModelState.IsValid)
            {
                await _context.StoreFeatsAsync(feat);
                return RedirectToAction(nameof(Index));
            }
            return View(feat);
        }

        // GET: ManageFeats/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Feats == null)
            {
                return NotFound();
            }

            var feat = await _context.GetFeatsByIdAsync(id);
            if (feat == null)
            {
                return NotFound();
            }
            return View(feat);
        }

        // POST: ManageFeats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeatId,FeatName,FeatEffect,DateAdded")] Feat feat)
        {
            if (id != feat.FeatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateFeatsAsync(feat);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatExists(feat.FeatId))
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
            return View(feat);
        }

        // GET: ManageFeats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Feats == null)
            {
                return NotFound();
            }

            var feat = await _context.Feats
                .FirstOrDefaultAsync(m => m.FeatId == id);
            if (feat == null)
            {
                return NotFound();
            }

            return View(feat);
        }

        // POST: ManageFeats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Feats == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Feats'  is null.");
            }
            var feat = await _context.GetFeatsByIdAsync(id);
            if (feat != null)
            {
                await _context.DeleteFeatsAsync(feat);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FeatExists(int id)
        {
          return (_context.Feats?.Any(e => e.FeatId == id)).GetValueOrDefault();
        }
    }
}

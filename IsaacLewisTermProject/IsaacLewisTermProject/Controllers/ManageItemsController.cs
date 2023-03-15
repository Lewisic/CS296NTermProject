using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsaacLewisTermProject.Data;
using IsaacLewisTermProject.Models;
using Microsoft.AspNetCore.Identity;
using IsaacLewisTermProject.Repos;

namespace IsaacLewisTermProject.Controllers
{
    public class ManageItemsController : Controller
    {
        UserManager<AppUser> userManager;

        IHomebrewRepository _context;

        public ManageItemsController(IHomebrewRepository repo, UserManager<AppUser> userMngr)
        {
            _context = repo;
            userManager = userMngr;
        }

        // GET: ManageItems
        public async Task<IActionResult> Index()
        {
              return _context.Items != null ? 
                          View(await _context.Items.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Items'  is null.");
        }

        // GET: ManageItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: ManageItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,ItemRarity,ItemType,ItemEffect,Attunement,DateAdded")] Item item)
        {
            if (userManager != null)
            {
                item.User = await userManager.GetUserAsync(User);
                item.User.Name = item.User.UserName;
            }
            if (ModelState.IsValid)
            {
                await _context.StoreItemAsync(item);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: ManageItems/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: ManageItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,ItemRarity,ItemType,ItemEffect,Attunement,DateAdded")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateItemAsync(item);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
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
            return View(item);
        }

        // GET: ManageItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: ManageItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Items == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Items'  is null.");
            }
            var item = await _context.GetItemByIdAsync(id);
            if (item != null)
            {
                _context.DeleteItemAsync(item);
            }
            
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
          return (_context.Items?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}

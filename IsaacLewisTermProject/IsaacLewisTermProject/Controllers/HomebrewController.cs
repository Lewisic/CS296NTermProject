using IsaacLewisTermProject.Models;
using IsaacLewisTermProject.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsaacLewisTermProject.Controllers
{
    public class HomebrewController : Controller
    {
        IHomebrewRepository repo;
        UserManager<AppUser> userManager;
        public HomebrewController(IHomebrewRepository r, UserManager<AppUser> userMngr)
        {
            repo = r;
            userManager = userMngr;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Item
        public async Task<IActionResult> Item(string itemName, string userName)
        {
            List<Item> items;

            if (itemName != null)
            {
                items = await (from r in repo.Items where r.ItemName == itemName select r).ToListAsync<Item>();
            }
            else if (userName != null)
            {
                items = await (from r in repo.Items where r.User.UserName== userName select r).ToListAsync<Item>();
            }
            else
            {
                items = repo.Items.ToList<Item>();
            }
            return View(items);
        }

        [Authorize]
        public IActionResult ItemAdd() { return View(); }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ItemAdd(Item item)
        {
            //if (ModelState.IsValid)
            {
                if (userManager != null)
                {
                    item.User = await userManager.GetUserAsync(User);
                    item.User.Name = item.User.UserName;
                }

                if (await repo.StoreItemAsync(item) > 0)
                {
                    return RedirectToAction("Item", new { itemId = item.ItemId });
                }
            }
            return View();
        }

        #endregion

    }
}

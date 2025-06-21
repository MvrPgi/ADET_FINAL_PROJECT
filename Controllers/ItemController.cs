using ADET_FINAL_PROJECT.Data;
using ADET_FINAL_PROJECT.Models;
using ADET_FINAL_PROJECT.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADET_FINAL_PROJECT.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ItemController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel viewModel)
        {
            var quantity = viewModel.Quantity;
            var item = new Item
            {
                Name = viewModel.Name,
                Category = viewModel.Category,
                Description = viewModel.Description,
                Quantity = viewModel.Quantity,
                Status = quantity < 10 ? "Low" :
                         quantity > 20 ? "High" : "Medium",
                CreatedAt = DateTime.UtcNow 
            };

            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Inventory");
        }

        public IActionResult NewAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewAdd(AddItemViewModel viewModel)
        {
            var quantity = viewModel.Quantity;

            var item = new Item
            {
                Name = viewModel.Name,
                Category = viewModel.Category,
                Description = viewModel.Description,
                Quantity = quantity, 
                Status = quantity < 10 ? "Low" :
                         quantity > 20 ? "High" : "Medium",
                CreatedAt = DateTime.UtcNow 

            };

            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Inventory");
        }

        [HttpGet]
        public async Task<IActionResult> Inventory()
        {
            var items = await dbContext.Items.ToListAsync();

            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var items = await dbContext.Items.ToListAsync();

            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var item = await dbContext.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            dbContext.Items.Remove(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Delete");


        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var items = await dbContext.Items.ToListAsync(); 
            return View(items);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed()
        {
            var selectedItemId = Request.Form["SelectedItemId"];
            if (!Guid.TryParse(selectedItemId, out Guid id))
            {
                return BadRequest();
            }

            var item = await dbContext.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }


            item.Name = Request.Form["Name"]!;
            item.Category = Request.Form["Category"]!;
            item.Description = Request.Form["Description"]!;
            item.Quantity = int.TryParse(Request.Form["Quantity"], out var q) ? q : 0;
            item.Status = q < 10 ? "Low" : q > 20 ? "High" : "Medium";
            item.CreatedAt = DateTime.UtcNow; 

            dbContext.Items.Update(item);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Edit");
        }

    }
}

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
            var item = new Item
            {
                Name = viewModel.Name,
                Category = viewModel.Category,
                Description = viewModel.Description,
                Quantity = viewModel.Quantity,
                Status = "High" // Default value for Status
            };

            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return View();
        }

        public IActionResult NewAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewAdd(AddItemViewModel viewModel)
        {
            int quantity = int.TryParse(viewModel.Quantity, out int q) ? q : 0;
            var item = new Item
            {
                Name = viewModel.Name,
                Category = viewModel.Category,
                Description = viewModel.Description,
                Quantity = viewModel.Quantity,
                Status = quantity < 10 ? "Low" :
                         quantity > 20 ? "High" : "Medium"
            };

            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return View();
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
        public async Task<IActionResult> EditConfirmed(Guid id, AddItemViewModel viewModel)
        {
            var item = await dbContext.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = viewModel.Name;
            item.Category = viewModel.Category;
            item.Description = viewModel.Description;
            item.Quantity = viewModel.Quantity;
            item.Status = "High"; // Default value for Status
            dbContext.Items.Update(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Edit");
        }
    }
}

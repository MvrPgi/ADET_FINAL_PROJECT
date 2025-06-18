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

        [HttpGet]
        public async Task<IActionResult> Inventory()
        {
            var items = await dbContext.Items.ToListAsync();

            return View(items);
        }
    }
}

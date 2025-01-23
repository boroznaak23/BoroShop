using Lab2.Data;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopContext dbContext;

        public ProductsController(ShopContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var products = await dbContext.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await dbContext.Products.ToListAsync();

            return View(products);
        }   
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var product = await dbContext.Products.FindAsync(Id);

            return View(product);
        }
        
        [HttpPost]
        public IActionResult Products(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                // Дані передаються у вигляд
                return View(model);
            }

            // Якщо модель недійсна
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            var product = new ProductModel
            {
                Name = viewModel.Name,
                Model = viewModel.Model,
                Category = viewModel.Category,
                Memory = viewModel.Memory
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Products");
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel viewModel)
        { 
        var product = await dbContext.Products.FindAsync(viewModel.Id);

        if (product is not null) {
            product.Name = viewModel.Name;
            product.Model = viewModel.Model;
            product.Category = viewModel.Category;
            product.Memory = viewModel.Memory;

            await dbContext.SaveChangesAsync();
        }
        return RedirectToAction("Products");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductModel viewModel)
        {
            var product = await dbContext.Products.FindAsync(viewModel.Id);

            if (product is not null)
            {
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Products");
        }







        
    }
}

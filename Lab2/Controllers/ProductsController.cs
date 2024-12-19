using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Products()
        {
            return View(new ProductModel());
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
    }
}

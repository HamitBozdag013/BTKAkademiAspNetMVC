using Entities.Models;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var values = _manager.ProductService.GetAllProducts(false);
            return View(values);
        }

        public IActionResult Create()
        {
            //ViewBag.Categories = _manager.CategoryService.GetAllCategories(false);
            //Create.cshtml sayfasındaki foreach yapısından kurtulmak ve TagHelper kullanmak için aşağıdaki gibi de yapabiliriz.
            ViewBag.Categories = new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var value = _manager.ProductService.GetOneProduct(id, false);
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }

}
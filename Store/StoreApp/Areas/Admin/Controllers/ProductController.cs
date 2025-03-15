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
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operation
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);

                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/",file.FileName);
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var value = _manager.ProductService.GetOneProductForUpdate(id, false);
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operation
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);

                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/",file.FileName);
                _manager.ProductService.UpdateProduct(productDto);
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
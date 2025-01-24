using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using Entities.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        // public IEnumerable<Product> Index()
        // {
        //     var context = new RepositoryContext(
        //         new DbContextOptionsBuilder<RepositoryContext>().UseSqlite("Data Source=C:\\SQLite\\BTKAkademiAspNet\\Store\\StoreApp\\ProductDB.db").Options
        //         );

        //     return context.Products;
        // }

        // Yukarıdaki işlemi artık Dependency Injection ile daha kolay bir şekilde yapabiliyoruz.

        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Products.ToList();
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            var value = _context.Products.First(p=>p.ProductId.Equals(id));
            return View(value);
        }
    }

}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;

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

        // private readonly RepositoryContext _context;

        //  public ProductController(RepositoryContext context)
        // {
        //     _context = context;
        // }

        //   public IActionResult Index()
        // {
        //     var values = _context.Products.ToList();
        //     return View(values);
        // }

        // public IActionResult Detail(int id)
        // {
        //     var value = _context.Products.First(p => p.ProductId.Equals(id));
        //     return View(value);
        // }
        
        private readonly IRepositoryManager _manager;


        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var values = _manager.Product.GetAllProducts(false).ToList();
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            var value=_manager.Product.GetOneProduct(id,false);
            return View(value);
        }
    }

}
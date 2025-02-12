using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        //Burada veritabanına bağlnabilmek için RepositoryContext ten bir nesne türetip
        //constructor yapısı ile bu ProductSummary class 'ı her çağırıldığında veritabanı bağlantı işleminin gerçekleşmesini sağlıyoruz. 
        // private readonly RepositoryContext _context;

        // public ProductSummary(RepositoryContext context)
        // {
        //     _context = context;
        // }

        // public string Invoke()
        // {
        //     return _context.Products.Count().ToString();
        // }
        /* 
        Üstteki kullanımda products sayısını repository üzerinden direk veritabanından aldık fakat burada eğer ki veritabanında 100 ürün var
        ama bunun 20 tanesi tükendiği için şuan satışta değil ve bu işlem service yapıları yani örneğin ProductManager tarafından kontrol ediliyorsa
        sıkıntı oluşturur. 
        */
        //Bu yüzden bu işlemi aşağıdaki gibi service üzerinden yapmak daha doğru olacaktır.

        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
        }

    }
}
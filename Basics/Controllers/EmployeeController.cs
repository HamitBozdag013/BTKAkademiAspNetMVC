using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index1()
        {
             string message=$"Hello World.{DateTime.Now.ToString()}";
            return View("Index1",message);
        }

       public ViewResult Index2()
        {
            var names=new String[]
            {
                "Hamit",
                "Merve",
                "Erva Betül",
                "Ömer Enes"
            };
            return View(names);
        }

        public IActionResult Index3()
        {
            var list=new List<Employee>()
            {
                new Employee(){Id=1, FirstName="Hamit", LastName="Bozdağ", Age=35},
                new Employee(){Id=2, FirstName="Merve", LastName="Bozdağ", Age=32},
                new Employee(){Id=3, FirstName="Erva Betül", LastName="Bozdağ", Age=7},
                new Employee(){Id=4, FirstName="Ömer Enes", LastName="Bozdağ", Age=2},

            };
            return View("Index3",list);
        }
    }
}
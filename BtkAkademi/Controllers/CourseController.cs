using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var values = Repository.Aplications;
            return View(values);
        }

        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Form kullanılan sayfalarda formun güvenliği için kullanılır.
        public IActionResult Apply([FromForm] Candidate candidate)
        {
            if (Repository.Aplications.Any(x => x.Email.Equals(candidate.Email)))
            {
                ModelState.AddModelError("", "There is already an application for you.");
            }

            if (ModelState.IsValid)
            {
                Repository.Add(candidate);
                return View("Feedback", candidate);
            }
            return View();
        }
    }

}
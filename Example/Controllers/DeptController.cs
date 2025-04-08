using Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    public class DeptController(ApplicationDbContext dbContext) : Controller
    {
        public IActionResult Index()
        {
            List<Department> deps = dbContext.Departments.ToList();

            return View("Index", deps);
        }
    }
}

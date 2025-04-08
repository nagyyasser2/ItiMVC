using Example.Models;
using Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    public class StudentController(ApplicationDbContext dbContext) : Controller
    {
        public IActionResult Details()
        {
            List<string> branches = new List<string> ();

            branches.Add("Cairo");
            branches.Add("Ismailia");
            branches.Add("Tanta");

            ViewData["Branches"] = branches;

            var student = dbContext.Students.FirstOrDefault();

            return View("Details", student);
        }

        public IActionResult DetailsWithVM()
        {
            List<string> branches = new List<string>();

            branches.Add("Cairo");
            branches.Add("Ismailia");
            branches.Add("Tanta");

            var student = dbContext.Students.FirstOrDefault();

            StudentWithBranchListViewModel stVm = new()
            {
                StdName = student.Name,
                StdImage = student.Image,
                Branches = branches,
                Temp = "realy a temp",
                Message = "Well Done!",
            };


            return View("DetailsWithVM", stVm); 
        }
    }
}

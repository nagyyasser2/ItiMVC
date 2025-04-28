using Example.Models;
using Example.Repository;
using Example.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    public class DeptController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeptController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new DepartmentViewModel
            {
                Department = new Department(),
                Departments = _departmentRepository.FindAll()
            };

            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveDepartment(DepartmentViewModel viewModel)
        {
            ModelState.Remove("Departments");

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("newerr", "this is newerr");
                viewModel.Departments = _departmentRepository.FindAll();
                return View("Index", viewModel);
            }

            var model = viewModel.Department;

            if (model.Id == 0)
            {
                // Adding a new department
                _departmentRepository.Insert(model);
            }
            else
            {
                // Updating an existing department
                _departmentRepository.Edit(model.Id, model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _departmentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

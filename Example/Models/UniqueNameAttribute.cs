using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Example.Models;

namespace Example.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var _context = (ApplicationDbContext)validationContext
                                .GetService(typeof(ApplicationDbContext));
            if (_context == null)
                throw new Exception("ApplicationDbContext not available");

            // Get the current department object being validated
            var department = validationContext.ObjectInstance as Department;
            if (department == null)
                return ValidationResult.Success;

            string newName = value.ToString();

            // Find departments with the same name but exclude the current department being edited
            var alreadyUsed = _context.Departments.FirstOrDefault(d =>
                d.Name == newName && d.Id != department.Id);

            if (alreadyUsed != null)
            {
                return new ValidationResult("Name must be unique ya king 😎");
            }

            return ValidationResult.Success;
        }
    }
}
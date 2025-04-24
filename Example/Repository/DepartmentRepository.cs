using Example.Models;
using System.Collections.Generic;
using System.Linq;

namespace Example.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Department> FindAll()
        {
            return dbContext.Departments.ToList();
        }

        public Department FindOneById(int id)
        {
            return dbContext.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Department department)
        {
            dbContext.Departments.Add(department);
            dbContext.SaveChanges();
        }

        public void Edit(int id, Department department)
        {
            var existingDept = this.FindOneById(id);
            if (existingDept == null) return;

            existingDept.Name = department.Name;
            existingDept.ManagerName = department.ManagerName;

            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var existingDept = this.FindOneById(id);
            if (existingDept == null) return;

            dbContext.Departments.Remove(existingDept);
            dbContext.SaveChanges();
        }
    }
}

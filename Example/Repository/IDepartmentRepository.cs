using Example.Models;
using System.Collections.Generic;

namespace Example.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> FindAll();
        Department FindOneById(int id);
        void Insert(Department department);
        void Edit(int id, Department department);
        void Delete(int id);
    }
}

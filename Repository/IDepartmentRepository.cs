using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexappTestSolution.Models
{
    public interface IDepartmentRepository
    {
        Department Get(long id);
        IEnumerable<Department> GetAll();
        void Create(Department newDepartment);
        void Update(Department changedDepartment);
        void Delete(long id);

    }
}

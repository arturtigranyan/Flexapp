using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexappTestSolution.Models
{
    public class FaDepartmentRepository : IDepartmentRepository
    {
        private FaDbContext context;
        public FaDepartmentRepository(FaDbContext ctx)
        {
            context = ctx;
        }
        public Department Get(long id)
        {
            return context.Department.Find(id);
        }
        public IEnumerable<Department> GetAll()
        {
            return context.Department;
        }
        public void Create(Department newDepartment)
        {
            context.Add(newDepartment);
            context.SaveChanges();
        }
        public void Update(Department updatedDepartment)
        {
            context.Update(updatedDepartment);
            context.SaveChanges();
        }
        public void Delete(long id)
        {
            context.Remove(Get(id));
            context.SaveChanges();
        }
    }
}

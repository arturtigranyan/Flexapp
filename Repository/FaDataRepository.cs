using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace FlexappTestSolution.Models
{
    public class FaDataRepository : IFaDataRepository
    {
        private FaDbContext context;
        public FaDataRepository(FaDbContext ctx)
        {
            context = ctx;
        }

        public Employee GetEmployee(long id)
        {
            return context.Employee.Include(emp => emp.Department).First(emp => emp.Id == id);
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employee.Include(emp => emp.Department);
        }

        public IEnumerable<Employee> GetFilteredEmployee(string firstName = null, decimal? wage = null, bool includeRelated = true)
        {
            IQueryable<Employee> data = context.Employee;
            if(firstName != null)
            {
                data = data.Where(emp => emp.FirstName == firstName);
            }
            if(wage != null)
            {
                data = data.Where(emp => emp.Wage == wage);
            }
            if (includeRelated)
            {
                data = data.Include(emp => emp.Department);
            }
            return data;
        }

        public void CreateEmployee(Employee newEmployee)
        {
            newEmployee.Id = 0;
            context.Employee.Add(newEmployee);
            context.SaveChanges();
        }
        public void UpdateEmployee(Employee changedEmployee, Employee originalEmployee = null)
        {
            if (originalEmployee == null)
            {
                originalEmployee = context.Employee.Find(changedEmployee.Id);
            }
            else
            {
                context.Employee.Attach(originalEmployee);
            }
            originalEmployee.FirstName = changedEmployee.FirstName;
            originalEmployee.LastName = changedEmployee.LastName;
            originalEmployee.Wage = changedEmployee.Wage;

            originalEmployee.Department.Name = changedEmployee.Department.Name;

            context.SaveChanges();
        }

        public void DeleteEmployee(long id)
        {
            Employee emp = this.GetEmployee(id);
            context.Employee.Remove(emp);
            if (emp.Department != null)
            {
                context.Remove<Department>(emp.Department);
            }
            context.SaveChanges();
        } 

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexappTestSolution.Models
{
    public interface IFaDataRepository
    {        
        Employee GetEmployee(long id);
        IEnumerable<Employee> GetAllEmployee();
        void CreateEmployee(Employee newEmployee);
        void UpdateEmployee(Employee changedEmployee, Employee originalemployee = null);
        void DeleteEmployee(long id);
        IEnumerable<Employee> GetFilteredEmployee(string firstName = null, decimal? wage = null, bool includeRelated = true);
    }
}

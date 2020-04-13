using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlexappTestSolution.Models;

namespace FlexappTestSolution.Controllers
{
    public class HomeController : Controller
    {        
        private IFaDataRepository repository;

        public HomeController(IFaDataRepository repo)
        {
            repository = repo;            
        }

        public IActionResult Index(string firstName = null, decimal? wage = null, bool includeRelated = true)
        {
            var employee = repository.GetFilteredEmployee(firstName, wage, includeRelated);
            ViewBag.FirstName = firstName;
            ViewBag.Wage = wage;
            ViewBag.includeRelated = includeRelated;
            return View(employee);
        }

        public IActionResult Create()
        {
            ViewBag.CreateMode = true;
            return View("Editor", new Employee());
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            repository.CreateEmployee(employee);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long id)
        {
            ViewBag.CreateMode = false;
            return View("Editor", repository.GetEmployee(id));
        }

        [HttpPost]
        public IActionResult Edit(Employee employee, Employee original)
        {
            repository.UpdateEmployee(employee, original);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            repository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

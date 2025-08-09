using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Web.Controllers
{


    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Fields = await _employeeService.GetAllFieldsAsync();
            return View(new Employee());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee, IFormCollection form)
        {
            var result = await _employeeService.CreateEmployeeAsync(employee, form);

            if (!result.Success)
            {
                ViewBag.Fields = await _employeeService.GetAllFieldsAsync();
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return View(employee);
            }

            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            ViewBag.Fields = await _employeeService.GetAllFieldsAsync();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, form);

            if (!result.Success)
            {
                ViewBag.Fields = await _employeeService.GetAllFieldsAsync();
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }

                // Reload employee with existing values
                var employees = await _employeeService.GetAllEmployeesAsync();
                var employee = employees.FirstOrDefault(e => e.Id == id);
                return View(employee);
            }

            return RedirectToAction("Index");
        }

    }

}

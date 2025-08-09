using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Web.Controllers
{


    public class EmployeeFieldController : Controller
    {
        private readonly IEmployeeFieldService _employeeFieldService;

        public EmployeeFieldController(IEmployeeFieldService employeeFieldService)
        {
            _employeeFieldService = employeeFieldService;
        }

        public async Task<IActionResult> Index()
        {
            var fields = await _employeeFieldService.GetAllFieldsAsync();
            return View(fields);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeField model)
        {


            await _employeeFieldService.CreateFieldAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var field = await _employeeFieldService.GetFieldByIdAsync(id);
            if (field == null) return NotFound();
            return View(field);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeField model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _employeeFieldService.UpdateFieldAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var field = await _employeeFieldService.GetFieldByIdAsync(id);
            if (field == null) return NotFound();
            return View(field);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeFieldService.DeleteFieldAsync(id);
            return RedirectToAction("Index");
        }

    }

}

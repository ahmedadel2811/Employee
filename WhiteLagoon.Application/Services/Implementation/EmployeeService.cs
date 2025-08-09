using Microsoft.AspNetCore.Http;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _unitOfWork.Employees.GetAllWithFieldsAsync();
        }

        public async Task<List<EmployeeField>> GetAllFieldsAsync()
        {
            return await _unitOfWork.EmployeeFields.GetAllAsync();
        }

        public async Task<(bool Success, List<string> Errors)> CreateEmployeeAsync(Employee employee, IFormCollection form)
        {
            var (success, errors) = await MapAndValidateFieldsAsync(employee, form);

            if (!success)
                return (false, errors);

            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Save();
            return (true, new());
        }

        public async Task<(bool Success, List<string> Errors)> UpdateEmployeeAsync(int id, IFormCollection form)
        {
            var employee = _unitOfWork.Employees.GetByIdWithFields(id);

            if (employee == null)
                return (false, new List<string> { "Employee not found." });

            var (success, errors) = await MapAndValidateFieldsAsync(employee, form);

            if (!success)
                return (false, errors);

            _unitOfWork.Employees.Update(employee);
            _unitOfWork.Save();
            return (true, new());
        }

        // Shared Dynamic Mapping & Validation Logic
        private async Task<(bool Success, List<string> Errors)> MapAndValidateFieldsAsync(Employee employee, IFormCollection form)
        {
            var fields = await _unitOfWork.EmployeeFields.GetAllAsync();
            var errors = new List<string>();

            if (employee.FieldValues == null)
                employee.FieldValues = new List<EmployeeFieldValue>();

            foreach (var field in fields)
            {
                var value = form[$"Field_{field.Id}"];

                if (field.IsRequired && string.IsNullOrWhiteSpace(value))
                    errors.Add($"{field.Name} is required.");

                var existingValue = employee.FieldValues.FirstOrDefault(fv => fv.FieldId == field.Id);
                if (existingValue != null)
                {
                    existingValue.Value = value;
                }
                else
                {
                    employee.FieldValues.Add(new EmployeeFieldValue
                    {
                        EmployeeId = employee.Id,
                        FieldId = field.Id,
                        Value = value
                    });
                }
            }

            return (!errors.Any(), errors);
        }
    }






}


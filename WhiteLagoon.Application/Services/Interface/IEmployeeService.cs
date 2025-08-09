using Microsoft.AspNetCore.Http;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<List<EmployeeField>> GetAllFieldsAsync();
        Task<(bool Success, List<string> Errors)> CreateEmployeeAsync(Employee employee, IFormCollection form);
        //
        Task<(bool Success, List<string> Errors)> UpdateEmployeeAsync(int id, IFormCollection form);


    }



}

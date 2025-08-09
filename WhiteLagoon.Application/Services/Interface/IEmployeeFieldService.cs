using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Interface
{
    public interface IEmployeeFieldService
    {
        Task<List<EmployeeField>> GetAllFieldsAsync();
        Task<bool> CreateFieldAsync(EmployeeField field);

        //
        Task<EmployeeField> GetFieldByIdAsync(int id);
        Task<bool> UpdateFieldAsync(EmployeeField field);
        Task<bool> DeleteFieldAsync(int id);
    }



}

using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IEmployeeFieldRepository
    {
        Task<List<EmployeeField>> GetAllAsync();
        void Add(EmployeeField field);

        //

        Task<EmployeeField> GetByIdAsync(int id);

        void Update(EmployeeField field);

        void Delete(EmployeeField field);

    }


}

using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllWithFieldsAsync();

        void Add(Employee employee);

        //
        Employee GetByIdWithFields(int id);

        void Update(Employee employee);


    }


}

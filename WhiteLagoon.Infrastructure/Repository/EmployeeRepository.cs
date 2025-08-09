using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) => _context = context;

        public async Task<List<Employee>> GetAllWithFieldsAsync()
        {
            return await _context.Employees
                .Include(e => e.FieldValues)
                .ThenInclude(v => v.Field)
                .ToListAsync();
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
        }


        public Employee GetByIdWithFields(int id)
        {
            return _context.Employees
                .Include(e => e.FieldValues)
                .ThenInclude(fv => fv.Field)
                .FirstOrDefault(e => e.Id == id);
        }
        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }
    }

}

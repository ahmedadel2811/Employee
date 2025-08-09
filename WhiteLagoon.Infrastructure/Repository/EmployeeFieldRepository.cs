using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class EmployeeFieldRepository : IEmployeeFieldRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeFieldRepository(ApplicationDbContext context) => _context = context;

        public async Task<List<EmployeeField>> GetAllAsync()
        {
            return await _context.EmployeeFields.ToListAsync();
        }

        public void Add(EmployeeField field)
        {
            _context.EmployeeFields.Add(field);
        }

        //

        public async Task<EmployeeField> GetByIdAsync(int id)
        {
            return await _context.EmployeeFields.FindAsync(id);
        }

        public void Update(EmployeeField field)
        {
            _context.EmployeeFields.Update(field);
        }

        public void Delete(EmployeeField field)
        {
            _context.EmployeeFields.Remove(field);
        }
    }

}

using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Implementation
{
    public class EmployeeFieldService : IEmployeeFieldService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeFieldService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<EmployeeField>> GetAllFieldsAsync()
        {
            return await _unitOfWork.EmployeeFields.GetAllAsync();
        }

        public async Task<EmployeeField> GetFieldByIdAsync(int id)
        {
            return await _unitOfWork.EmployeeFields.GetByIdAsync(id);
        }

        public async Task<bool> CreateFieldAsync(EmployeeField field)
        {
            _unitOfWork.EmployeeFields.Add(field);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateFieldAsync(EmployeeField field)
        {
            _unitOfWork.EmployeeFields.Update(field);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteFieldAsync(int id)
        {
            var field = await _unitOfWork.EmployeeFields.GetByIdAsync(id);
            if (field == null) return false;

            _unitOfWork.EmployeeFields.Delete(field);
            await _unitOfWork.SaveAsync();
            return true;
        }

    }

}

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IVillaRepository Villa { get; }
        IVillaNumberRepository VillaNumber { get; }
        IBookingRepository Booking { get; }
        IApplicationUserRepository User { get; }
        IAmenityRepository Amenity { get; }
        IEmployeeRepository Employees { get; }
        IEmployeeFieldRepository EmployeeFields { get; }





        void Save();
        Task SaveAsync();

    }
}

using LibraryItems.Api.Entities;

namespace LibraryItems.Api.Repositries
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<bool> AddEmployee(Employee emp);
        Task<bool> UpdateEmployee(Employee emp);
        public Task<bool> DeleteEmployee(int id);
        public Task<Employee> GetEmployee(int id);
    }
}

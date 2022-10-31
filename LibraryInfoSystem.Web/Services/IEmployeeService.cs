using LibraryItems.Api.Dtos;
using LibraryItems.Api.Entities;

namespace LibraryInfoSystem.Web.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployees();
        Task CreateEmployee(Employee emp);
        Task<Employee> GetEmployee(int id);
        Task<bool> DeleteEmployee(int id);
        Task UpdateEmployee(Employee emp, int id);
    }
}

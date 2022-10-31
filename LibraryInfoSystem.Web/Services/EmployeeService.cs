using LibraryItems.Api.Dtos;
using LibraryItems.Api.Entities;

namespace LibraryInfoSystem.Web.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {

            return await _httpClient.GetFromJsonAsync<List<EmployeeDto>>("api/Employees");
        }

        public async Task CreateEmployee(Employee emp)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Employees", emp);
        }

        
        public async Task<Employee> GetEmployee(int id)
        {
            var abc = await _httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
            return abc;
        }

        //public async Task<Category> GetCategory(int id)
        //{
        //    return await _httpClient.GetFromJsonAsync<Category>($"api/Categories/{id}");
        //}

        public async Task<bool> DeleteEmployee(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Employees/{id}");
            var status = await result.Content.ReadFromJsonAsync<bool>();
            return status;
        }


        public async Task UpdateEmployee(Employee emp, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Employees/{id}", emp);
        }
    }
}

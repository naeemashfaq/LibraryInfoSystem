using LibraryItems.Api.Entities;
using LibraryItems.Api.Dtos;
using LibraryItems.Api.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryItems.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public List<EmployeeDto> empList { get; set; }
        public List<EmployeeDto> empList1 { get; set; }
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();

           empList = (from emp in employees
                         join mngr in employees on emp.ManagerId equals mngr.Id into gj
                         from submgr in gj.DefaultIfEmpty()
                         select new EmployeeDto
                         {
                              Id =  emp.Id,
                             FirstName= emp.FirstName,
                             LastName = emp.LastName,
                             Salary= emp.Salary,
                             IsCEO=emp.IsCEO,
                             IsManager=emp.IsManager,
                             ManagerId=emp.ManagerId,
                             ManagerName = submgr?.FirstName ?? string.Empty

                         }).ToList();

            var query = empList.GroupBy(x => x.FirstName);


            for (int i = 0; i < empList.Count; i++)
            {
                if (empList[i].IsCEO == true)
                {
                    empList[i].Status = "CEO";
                }
                else if (empList[i].IsManager == true)
                {
                    empList[i].Status = "Manager";
                }
                else
                {
                    empList[i].Status = "Employee";
                }

            }


            empList = empList.OrderBy(x => x.Status).ToList();

                return Ok(empList);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddEmployee(Employee emp)
        {
            var status = await _employeeRepository.AddEmployee(emp); 

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{emp.FirstName} could not be added.");

            }

            return Ok(true);
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<bool>> DeleteEmployee(int id)
        //{
        //    bool status = await _employeeRepository.DeleteEmployee(id); 
        //    if (status == false)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, false);
        //    }
        //    else
        //    {
        //        return Ok(true);
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEmpp(int id)
        {
            bool status = await _employeeRepository.DeleteEmployee(id); 

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }
            else
            {
                return Ok(true);
            }
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateEmployee(int id, Employee emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
                
            }
            bool status = await _employeeRepository.UpdateEmployee(emp); 
            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{emp.FirstName} could not be updated");
            }

            return Ok(true);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpp(int id)
        {
            Employee emp = await _employeeRepository.GetEmployee(id); 

            if (emp == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No employee found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, emp);
        }
    }
}

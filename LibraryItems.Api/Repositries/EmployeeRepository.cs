using Microsoft.EntityFrameworkCore;
using LibraryItems.Api.Data;
using LibraryItems.Api.Entities;

namespace LibraryItems.Api.Repositries
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly LibraryDbContext _context;

        public EmployeeRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddEmployee(Employee emp)
        {
            try
            {
                
                if (emp.IsCEO == true)
                {
                    var isCEO = await _context.Employees.Where(x => x.IsCEO == true).FirstOrDefaultAsync();

                    if (isCEO == null)
                    {
                        await _context.Employees.AddAsync(emp);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    await _context.Employees.AddAsync(emp);
                    await _context.SaveChangesAsync();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                return false; // An error occured
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var dbemp = await _context.Employees.FindAsync(id);
                if (dbemp == null)
                {
                    return false;
                }
                var dbMngId = await _context.Employees.Where(x => x.ManagerId == id).FirstOrDefaultAsync(); 
                               
                if (dbMngId == null)
                {
                    _context.Employees.Remove(dbemp);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                return await _context.Employees.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                var employees = await _context.Employees.ToListAsync();
                             





                return employees;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateEmployee(Employee emp)
        {
            try
            {
                _context.Entry(emp).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

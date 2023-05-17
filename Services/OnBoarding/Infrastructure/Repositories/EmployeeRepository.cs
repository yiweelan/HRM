using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private OnBoardingDbContext _dbContext;

        public EmployeeRepository(OnBoardingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var emps = await _dbContext.Employees.ToListAsync();
            return emps;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
            return emp;
        }
    }
}

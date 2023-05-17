using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseModel>> GetAllEmployees();
        Task<EmployeeResponseModel> GetEmployeeById(int id);
        Task<int> AddEmployee(EmployeeRequestModel model);
        Task<int> UpdateEmployee(EmployeeRequestModel model);
    }
}

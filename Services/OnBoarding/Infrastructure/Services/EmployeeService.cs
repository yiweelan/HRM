using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeResponseModel>> GetAllEmployees()
        {
            var emps = await _employeeRepository.GetAllEmployees();

            var employeeReponseModel = new List<EmployeeResponseModel>();

            foreach( var emp in emps)
            {
                employeeReponseModel.Add(new EmployeeResponseModel
                {
                    Id = emp.Id, Email = emp.Email,
                    FirstName = emp.FirstName, LastName = emp.LastName,
                    SSN = emp.SSN
                });
            }

            return employeeReponseModel;
        }

        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var emp = await _employeeRepository.GetEmployeeById(id);
            if (emp == null)
            {
                return null;
            }

            var employeeResponseModel = new EmployeeResponseModel
            {
                Id = emp.Id,
                Email = emp.Email,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                SSN = emp.SSN
            };

            return employeeResponseModel;
        }

        public async Task<int> AddEmployee(EmployeeRequestModel model)
        {
            var empEntity = new Employee
            {

                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SSN = model.SSN,
                EmployeeIdentityId = Guid.NewGuid(),
                EmployeeStatusId = 1
            };

            var emp = await _employeeRepository.AddAsync(empEntity);
            return emp.Id;
        }

        public async Task<int> UpdateEmployee(EmployeeRequestModel model)
        {
            var empEntity = new Employee
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SSN = model.SSN,
                EmployeeIdentityId = Guid.NewGuid(),
                EmployeeStatusId = 1
            };

            var emp = await _employeeRepository.UpdateAsync(empEntity);
            return emp.Id;
        }
    }
}

using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnBoardingWeb.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

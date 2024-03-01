using Microsoft.AspNetCore.Mvc;
using APItest.Model;
using APItest.ViewModel;

namespace APItest.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.Name, employeeView.Age, null);

            _employeeRepository.Add(employee);

            return Ok();
        }

        [HttpGet] 
        public IActionResult Get()
        {
            var employees = _employeeRepository.Get();

            return Ok(employees);
        }
    }
}

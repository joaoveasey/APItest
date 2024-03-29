﻿using Microsoft.AspNetCore.Mvc;
using APItest.Model;
using APItest.ViewModel;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
                var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

                using Stream fileStream = new FileStream(filePath, FileMode.Create);
                employeeView.Photo.CopyTo(fileStream);

                var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

                _employeeRepository.Add(employee);

                return Ok();
        }

        
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            try
            {
                var dataBytes = System.IO.File.ReadAllBytes(employee.photo);
                return File(dataBytes, "image/png");
            }
            catch
            {
                return NotFound();
            }          
        }

        
        [HttpGet] 
        public IActionResult Get()
        {
            var employees = _employeeRepository.Get();

            return Ok(employees);
        }

        [HttpPatch]
        public IActionResult Patch(int id, [FromForm] EmployeeViewModel employeeView)
        {
            if (employeeView == null) 
                return BadRequest();

            Employee employee = _employeeRepository.Get(id);
            _employeeRepository.Remove(employee);

            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);

            var employee_ = new Employee(employeeView.Name, employeeView.Age, filePath);
            _employeeRepository.Patch(employee_);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeRepository.Remove(employee);
            
            return Ok();
        }
    }
}

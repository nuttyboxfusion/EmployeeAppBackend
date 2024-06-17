using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeAppBackend.Controllers.Dto;
using EmployeeAppBackend.Domain;

namespace EmployeeAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeManager _employeeManager;

        public EmployeesController(EmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeManager.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(string id)
        {
            try
            {
                var employee = await _employeeManager.GetEmployeeByIdAsync(id);
                return Ok(employee);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(EmployeeDto employeeCreateDto)
        {
            try
            {
                var createdEmployee = await _employeeManager.CreateEmployeeAsync(employeeCreateDto);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(string id, EmployeeDto employeeEditDto)
        {
            try
            {
                var updatedEmployee = await _employeeManager.EditEmployeeAsync(id, employeeEditDto);
                return Ok(updatedEmployee);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            try
            {
                await _employeeManager.DeleteEmployeeAsync(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EntityModel.Repositories;
using EntityModel.Repositories.Interfaces;

namespace EntityModel.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IPgRepository<Employee> _employeeRepo;

        public EmployeeController(IPgRepository<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetByID(int id)
        {
            return await _employeeRepo.ExecuteSingle(
                Commands.Employee.GetByID(id)
            );
        }

        [HttpGet("dob/{dateOfBirth}")]
        public async Task<IEnumerable<Employee>> GetByDateOfBirth(DateTime dateOfBirth)
        {
            return await _employeeRepo.ExecuteMany(
                Commands.Employee.GetByDateOfBirth(dateOfBirth)
            );
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Interfaces;
using ReportApp.DTO;

namespace ReportApp.ReportAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet("GetAllEmployee")]
        public List<EmployeeDto> GetAll()
        {
            return _employeeServices.GetAll();
        }

        [HttpGet("GetEmployeeById/{id}")]
        public EmployeeDto GetById(Guid id)
        {
            return _employeeServices.GetById(id);
        }

        [HttpPost("UpdateEmployee")]
        public void Update(EmployeeDto entity)
        {
            _employeeServices.Update(entity);
        }
    }
}

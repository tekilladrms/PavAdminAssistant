using EmployeeService.Application.DTO;
using EmployeeService.Application.Employees.Queries.GetEmployeeById;
using EmployeeService.Application.Employees.Queries.GetAllEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using EmployeeService.Application.Employees.Commands.CreateEmployee;
using EmployeeService.Application.Employees.Commands.ChangeEmployee;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Application.Employees.Commands.DeleteEmployee;
using EmployeeService.Domain.ValueObjects;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator) => _mediator = mediator;


        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetAllEmployeesQuery()));


        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id) => Ok(await _mediator.Send(new GetEmployeeByIdQuery(id)));


        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post([FromBody] EmployeeDto request)
        {

            await _mediator.Send(new CreateEmployeeCommand(request));
            
        }


        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] EmployeeDto request)
        {
            var employeeDto = await _mediator.Send(new ChangeEmployeeCommand(request));

            if (employeeDto is null) throw new NotFoundException(nameof(employeeDto));

            return Ok(employeeDto);
        }


        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _mediator.Send(new DeleteEmployeeCommand(id));
        }
    }
}

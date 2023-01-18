using EmployeeService.Api.Contracts.V1;
using EmployeeService.Api.Contracts.V1.Requests;
using EmployeeService.Application.Employees.Commands.CreateEmployee;
using EmployeeService.Application.Employees.Commands.DeleteEmployee;
using EmployeeService.Application.Employees.Commands.SetJobTitleIdToEmployee;
using EmployeeService.Application.Employees.Commands.UpdateEmployee;
using EmployeeService.Application.Employees.Queries.GetAllEmployees;
using EmployeeService.Application.Employees.Queries.GetEmployeeById;
using EmployeeService.Application.Employees.Queries.GetEmployeesByJobTitleId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeService.Api.Controllers.V1;

[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator) => _mediator = mediator;


    [HttpGet(ApiRoutes.Employees.GetAll)]
    public async Task<IActionResult> GetAll() => 
        Ok(await _mediator.Send(new GetAllEmployeesQuery()));


    [HttpGet(ApiRoutes.Employees.GetById)]
    public async Task<IActionResult> GetEmployeeById([FromRoute] string employeeId) =>
        Ok(await _mediator.Send(new GetEmployeeByIdQuery(employeeId)));


    [HttpGet(ApiRoutes.Employees.GetAllByJobTitleId)]
    public async Task<IActionResult> GetAllByJobTitleId(string jobTitleId) =>
        Ok(await _mediator.Send(new GetEmployeesByJobTitleIdQuery(jobTitleId)));


    [HttpPost(ApiRoutes.Employees.Create)]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
    {
        var employeeDto = await _mediator.Send(new CreateEmployeeCommand(
            request.FirstName, request.LastName, request.PhoneNumber, request.BirthDate));

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        var locationUri = baseUrl + "/" + ApiRoutes.Employees.GetById.Replace("{employeeId}", employeeDto.Guid.ToString());

        return Created(locationUri, employeeDto);
    }


    [HttpPut(ApiRoutes.Employees.Update)]
    public async Task<IActionResult> Update([FromRoute] string employeeId, [FromBody] UpdateEmployeeRequest request)
    {
        return Ok(await _mediator.Send(new UpdateEmployeeCommand(
                employeeId, request.FirstName, request.LastName, request.PhoneNumber, request.BirthDate)));
    }
        

    [HttpDelete(ApiRoutes.Employees.Delete)]
    public async Task Delete([FromRoute] string employeeId) => await _mediator.Send(new DeleteEmployeeCommand(employeeId));


    //Access for Supervizer only
    [HttpPut(ApiRoutes.Employees.SetJobTitleIdToEmployee)]
    public async Task SetJobTitleIdToEmployee([FromRoute] string employeeId, [FromBody] SetJobTitleIdToEmployeeRequest request)
    {
        await _mediator.Send(new SetJobTitleIdToEmployeeCommand(employeeId, request.JobTitleId));
    }
}

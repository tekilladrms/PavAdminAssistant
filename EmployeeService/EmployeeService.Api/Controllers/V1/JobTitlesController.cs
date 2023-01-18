using EmployeeService.Api.Contracts.V1;
using EmployeeService.Api.Contracts.V1.Requests;
using EmployeeService.Application.DTO;
using EmployeeService.Application.JobTitles.Commands.ChangeJobTitle;
using EmployeeService.Application.JobTitles.Commands.CreateJobTitle;
using EmployeeService.Application.JobTitles.Commands.DeleteJobTitle;
using EmployeeService.Application.JobTitles.Queries.GetAllJobTitles;
using EmployeeService.Application.JobTitles.Queries.GetJobTitleById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeService.Api.Controllers.V1;

[ApiController]
public class JobTitlesController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobTitlesController(IMediator mediator) => _mediator = mediator;


    [HttpGet(ApiRoutes.JobTitles.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var jobTitles = await _mediator.Send(new GetAllJobTitlesQuery());

        if (jobTitles is null || jobTitles.Count == 0)
        {
            return NotFound();
        }

        return Ok(jobTitles);
    }

    
    [HttpGet(ApiRoutes.JobTitles.GetById)]
    public async Task<IActionResult> Get([FromRoute] string jobTitleId)
    {
        var jobTitle = await _mediator.Send(new GetJobTitleByIdQuery(jobTitleId));


        if (jobTitle is null)
        {
            return NotFound();
        }

        return Ok(jobTitle);
    }

    
    [HttpPost(ApiRoutes.JobTitles.Create)]
    public async Task<IActionResult> Create([FromBody] CreateJobTitleRequest request)
    {
        var jobTitleDtoResult = await _mediator.Send(new CreateJobTitleCommand(
            request.JobTitleName, request.SalaryAmount, request.SalaryCurrency, request.SalaryType, request.PercentageOfSales));

        return Ok(jobTitleDtoResult);
    }

    
    [HttpPut(ApiRoutes.JobTitles.Update)]
    public async Task<IActionResult> Update([FromRoute] string jobTitleId, [FromBody] UpdateJobTitleRequest request)
    {
        var jobTitleDtoResult = await _mediator.Send(new UpdateJobTitleCommand(
            jobTitleId, request.JobTitleName, request.SalaryAmount, request.SalaryCurrency, request.SalaryType, request.PercentageOfSales));

        return Ok(jobTitleDtoResult);
    }

    
    [HttpDelete(ApiRoutes.JobTitles.Delete)]
    public async Task Delete([FromRoute] string jobTitleId)
    {
        await _mediator.Send(new DeleteJobTitleCommand(jobTitleId));
    }
}

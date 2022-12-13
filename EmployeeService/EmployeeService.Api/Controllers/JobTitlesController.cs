﻿using EmployeeService.Application.DTO;
using EmployeeService.Application.Employees.Commands.DeleteEmployee;
using EmployeeService.Application.Employees.Queries.GetEmployeeById;
using EmployeeService.Application.JobTitles.ChangeJobTitle;
using EmployeeService.Application.JobTitles.CreateJobTitle;
using EmployeeService.Application.JobTitles.GetAllJobTitleById;
using EmployeeService.Application.JobTitles.GetAllJobTitles;
using EmployeeService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobTitlesController(IMediator mediator) => _mediator = mediator;


        // GET: api/<JobTitlesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var jobTitles = await _mediator.Send(new GetAllJobTitlesQuery());

            if (jobTitles is null || jobTitles.Count == 0)
            {
                return NotFound();
            }

            return Ok(jobTitles);
        }

        // GET api/<JobTitlesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var jobTitle = await _mediator.Send(new GetJobTitleByIdQuery(id));


            if (jobTitle is null)
            {
                return NotFound();
            }

            return Ok(jobTitle);
        }

        // POST api/<JobTitlesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobTitleDto request)
        {
            var jobTitleDtoResult = await _mediator.Send(new CreateJobTitleCommand(request));

            if (jobTitleDtoResult is null)
            {
                return NotFound();
            }

            return Ok(jobTitleDtoResult);
        }

        // PUT api/<JobTitlesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] JobTitleDto request)
        {
            var jobTitleDtoResult = await _mediator.Send(new ChangeJobTitleCommand(id, request));

            if (jobTitleDtoResult is null)
            {
                return NotFound();
            }
            return Ok(jobTitleDtoResult);
        }

        // DELETE api/<JobTitlesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id, [FromBody] EmployeeDto request)
        {
            
        }
    }
}

using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    // Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        // add references for ApplicationCore and Infra Projects
        // copy all DI registration including DbContext into API project Program.cs
        // copy the connection string from MVC appSetting to API appsetting

        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // http://localhost/api/jobs
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();

            // F5 -> Debugging, put breakpoints
            // ctrl+F5 -> Start without debugging
            // F10 -> next line
            // F11 Step into

            // return JSON data, AND also HTTP status codes
            // serialization C# objects into Json objects using System.Text.Json
            if(!jobs.Any())
            {
                // no jobs exists, then 404
                return NotFound(new {error = "No open Jobs found, please try later"});
            }
            return Ok(jobs);
        }

        // http://localhost/api/jobs/4
        [Route("{id:int}", Name = "GetJobDetails")]
        [HttpGet]
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job = await _jobService.GetJobById(id);
            if(job == null)
            {
                return NotFound(new { errorMessage = "No Job found for this id" });
            }

            return Ok(job);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }
            var job = await _jobService.AddJob(model);
            return CreatedAtAction("GetJobDetails", new { controller = "Jobs", id = job }, "Job Created");
        }
    }
}

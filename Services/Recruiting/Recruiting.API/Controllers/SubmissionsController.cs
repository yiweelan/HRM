using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        public SubmissionsController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllSubmissions()
        {
            var subs = await _submissionService.GetAllSubmissions();

            if (!subs.Any())
            {
                // no submissions exists, then 404
                return NotFound(new { error = "No submissions found, please try later" });
            }
            return Ok(subs);
        }

        [Route("{id:int}", Name = "GetSubmissionDetails")]
        [HttpGet]
        public async Task<IActionResult> GetSubmissionDetails(int id)
        {
            var sub = await _submissionService.GetSubmissionById(id);

            if(sub == null)
            {
                return NotFound(new { errorMessage = "No Submission found for this id" });
            }
            return Ok(sub);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }
            var sub = await _submissionService.AddSubmission(model);
            return CreatedAtAction("GetSubmissionDetails", new { controller = "Submissions", id = sub }, "Submission Created");
        }
    }
}

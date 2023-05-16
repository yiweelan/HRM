using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
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
    }
}

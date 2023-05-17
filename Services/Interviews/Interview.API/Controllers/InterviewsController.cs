using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewServcie _interviewServcie;

        public InterviewsController(IInterviewServcie interviewServcie)
        {
            _interviewServcie = interviewServcie;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllInterviews()
        {
            var interviews = await _interviewServcie.GetAllInterviews();

            if (!interviews.Any())
            {
                return NotFound(new { error = "No Interviews found, please try later" });
            }

            return Ok(interviews);
        }

        [Route("{id:int}", Name = "GetInterveiwDetails")]
        [HttpGet]
        public async Task<IActionResult> GetInterveiwDetails(int id)
        {
            var interview = await _interviewServcie.GetInterviewsById(id);

            if (interview == null)
            {
                return NotFound(new { errorMessage = "No Interview found for this id" });
            }

            return Ok(interview);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create(InterviewRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }
            var interview = await _interviewServcie.AddInterview(model);
            return CreatedAtAction("GetInterveiwDetails", new { controller = "Interviews", id = interview }, 
                "Interview Created");
        }

        //[Route("")]
        //[HttpPut("{id}")]
    }
}

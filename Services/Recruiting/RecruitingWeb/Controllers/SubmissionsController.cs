using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class SubmissionsController : Controller
    {
        private ISubmissionService _submissionService;

        public SubmissionsController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var subs = await _submissionService.GetAllSubmissions();
            return View(subs);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int jobId)
        {
            var sub = new SubmissionRequestModel { Id = jobId, JobId = jobId};
            return View(sub);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int jobId, SubmissionRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _submissionService.AddSubmission(model);
            return RedirectToAction("Index");
        }
    }
}

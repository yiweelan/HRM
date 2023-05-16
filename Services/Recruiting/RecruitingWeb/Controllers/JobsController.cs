using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        private IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // ASP.NET will assign a thread from thread pool to do this task
            // IO bound 2 sec, 10 ms, 10 sec, 300ms
            // network, locatio, database disk SSD, hard drive, SQL fast or slow, might not be optimized
            var jobs = await _jobService.GetAllJobs();
            // return all the jobs so that candidates can apply to the job
            return View(jobs);
        }

        [HttpGet]
        // get the job detail information
        public async Task<IActionResult> Details(int id)
        {
            var job = await _jobService.GetJobById(id);
            return View(job);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // dropdown of job status
            List<JobStatusLookUp> sl = new List<JobStatusLookUp>();
            sl = await _jobService.GetJobStatus();
            ViewBag.message = sl;
            // take the information from view and save to DB
            return View();
        }

        // Saving job information
        [HttpPost]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            // check if model is valid, on server
            if(!ModelState.IsValid)
            {
                return View();
            }

            // save data in database
            await _jobService.AddJob(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetJobsByDepartment(int id, int pageSize = 30, int pageNumber = 1)
        {
            var job = await _jobService.GetJobsByDepartment(id, pageSize, pageNumber);
            return View();
        }
    }
}

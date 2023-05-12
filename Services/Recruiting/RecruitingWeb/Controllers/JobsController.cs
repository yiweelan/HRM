using ApplicationCore.Contracts.Services;
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
        public IActionResult Details(int id)
        {
            var job = _jobService.GetJobById(id);
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
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
    }
}

using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<List<JobResponseModel>> GetAllJobs()
        {
            var jobs = await _jobRepository.GetAllJobs();

            var jobsResponseModel = new List<JobResponseModel>();

            foreach (var job in jobs)
            {
                jobsResponseModel.Add(new JobResponseModel
                {
                    Id = job.Id, Description = job.Description, Title = job.Title, 
                    StartDate = job.StartDate.GetValueOrDefault(), NumberOfPositions = job.NumberOfPositions
                });
            }

            return jobsResponseModel;
        }

        public async Task<JobResponseModel> GetJobById(int id)
        {
            var job = await _jobRepository.GetJobById(id);
            if(job == null)
            {
                return null;
            }
            var jobResponseModel = new JobResponseModel
            { 
                Id = job.Id, Title = job.Title, StartDate = job.StartDate.GetValueOrDefault(), Description = job.Description 
            };

            return jobResponseModel;
        }

        public async Task<int> AddJob(JobRequestModel model)
        {
            // call repos that will use EF core to save data
            var jobEntity = new Job
            {
                Title = model.Title, StartDate = model.StartDate, Description = model.Description,
                CreateOn = DateTime.UtcNow, NumberOfPositions = model.NumberOfPositions,
                JobStatusLookUpId = 1
            };

            var job = await _jobRepository.AddAsync(jobEntity);
            return job.Id;
        }

        public async Task<IEnumerable<JobResponseModel>> GetPaginatedJobs(int pageSize = 30, int pageNumber = 1)
        {
            var jobs = await _jobRepository.GetAllJobs();
            jobs = jobs.Skip(pageSize * pageNumber).Take(pageSize).ToList();
            var jobsResponseModel = new List<JobResponseModel>();

            foreach (var job in jobs)
            {
                jobsResponseModel.Add(new JobResponseModel
                {
                    Id = job.Id,
                    Description = job.Description,
                    Title = job.Title,
                    StartDate = job.StartDate.GetValueOrDefault(),
                    NumberOfPositions = job.NumberOfPositions
                });
            }

            return jobsResponseModel;
        }

        public async Task<IEnumerable<JobResponseModel>> GetJobsByDepartment(int id, int pageSize = 30, int pageNumber = 1)
        {
            var jobs = await _jobRepository.GetAllJobs();
            jobs = jobs.Skip(pageSize * pageNumber).Take(pageSize).ToList();
            var jobsResponseModel = new List<JobResponseModel>();

            foreach (var job in jobs)
            {
                if(job.Id == id)
                {
                    jobsResponseModel.Add(new JobResponseModel
                    {
                        Id = job.Id,
                        Description = job.Description,
                        Title = job.Title,
                        StartDate = job.StartDate.GetValueOrDefault(),
                        NumberOfPositions = job.NumberOfPositions
                    });
                }
            }

            return jobsResponseModel;
        }
    }
}

using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IJobService
    {
        Task<List<JobResponseModel>> GetAllJobs();

        Task<JobResponseModel> GetJobById(int id);

        Task<int> AddJob(JobRequestModel model);

        Task<IEnumerable<JobResponseModel>> GetPaginatedJobs(int pageSize = 30, int pageNumber = 1);

        Task<IEnumerable<JobResponseModel>> GetJobsByDepartment(int id, int pageSize = 30, int pageNumber = 1);
    }
}

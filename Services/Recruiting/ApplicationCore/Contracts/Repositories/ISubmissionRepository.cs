using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface ISubmissionRepository: IBaseRepository<Submission>
    {
        Task<List<Submission>> GetAllSubmissions();
        Task<Candidate> GetCandidateByEmail(string email);

        Task<Candidate> GetCandidateById(int id);

        Task<Job> GetJobById(int jobId);

        Task<Submission> GetSubmissionById(int id);
    }
}

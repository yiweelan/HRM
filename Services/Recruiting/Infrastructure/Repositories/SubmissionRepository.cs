using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
    {
        private RecruitingDbContext _dbContext;
        public SubmissionRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Submission>> GetAllSubmissions()
        {
            var submissions = await _dbContext.Submissions.ToListAsync();
            return submissions;
        }

        public async Task<Candidate> GetCandidateByEmail(string email)
        {
            var cand = await _dbContext.Candidates.FirstOrDefaultAsync(c => c.Email == email);
            return cand;
        }

        public async Task<Candidate> GetCandidateById(int id)
        {
            var cand = await _dbContext.Candidates.FirstOrDefaultAsync(c => c.Id == id);
            return cand;
        }

        public async Task<Job> GetJobById(int jobId)
        {
            var cand = await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
            return cand;
        }

        public async Task<Submission> GetSubmissionById(int id)
        {
            var sub = await _dbContext.Submissions.FirstOrDefaultAsync(s => s.Id == id);
            return sub;
        }
    }
}

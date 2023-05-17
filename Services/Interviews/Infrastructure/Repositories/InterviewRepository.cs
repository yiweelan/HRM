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
    public class InterviewRepository: BaseRepository<Interview>, IInterviewRepository
    {
        private InterviewsDbContext _dbContext;

        public InterviewRepository(InterviewsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Interview>> GetAllInterviews()
        {
            var interviews = await _dbContext.Interviews.ToListAsync();
            return interviews;
        }

        public async Task<Interview> GetInterviewById(int id)
        {
            var interview = await _dbContext.Interviews.FirstOrDefaultAsync(i => i.Id == id);
            return interview;
        }
    }
}

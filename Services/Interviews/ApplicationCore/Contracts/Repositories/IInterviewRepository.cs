using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IInterviewRepository : IBaseRepository<Interview>
    {
        Task<List<Interview>> GetAllInterviews();

        Task<Interview> GetInterviewById(int id);
    }
}

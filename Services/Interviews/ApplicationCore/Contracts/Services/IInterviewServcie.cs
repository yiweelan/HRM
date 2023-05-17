using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IInterviewServcie
    {
        Task<List<InterviewResponseModel>> GetAllInterviews();

        Task<InterviewResponseModel> GetInterviewsById(int id);

        Task<int> AddInterview(InterviewRequestModel model);

        Task<Interview> UpdateInterview(Interview model);

        Task<int> DeleteInterview(int id);

        Task<IEnumerable<InterviewResponseModel>> GetPaginatedInterviews(int pageSize = 30, int pageNumber = 1);
    }
}

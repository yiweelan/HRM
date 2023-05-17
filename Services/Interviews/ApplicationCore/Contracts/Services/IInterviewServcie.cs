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
    }
}

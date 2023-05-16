using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepository;

        public SubmissionService(ISubmissionRepository submissionRepository)
        {
            _submissionRepository = submissionRepository;
        }

        public async Task<SubmissionResponseModel> GetSubmissionById(int id)
        {
            var sub = await _submissionRepository.GetSubmissionById(id);

            if (sub == null)
            {
                return null;
            }

            var submissionReponseModel = new SubmissionResponseModel
            {
                Id = sub.Id,
                JobId = sub.JobId,
                CandidateId = sub.CandidateId
            };

            return submissionReponseModel;
        }

        public async Task<int> AddSubmission(SubmissionRequestModel model)
        {
            var cand = _submissionRepository.GetCandidateById(model.CandidateId);

            var subEntity = new Submission
            {
                JobId = model.JobId,
                CandidateId = cand.Result.Id,
                SubmittedOn = DateTime.UtcNow
            };

            var sub = await _submissionRepository.AddAsync(subEntity);
            return sub.Id;
        }

        public async Task<List<SubmissionResponseModel>> GetAllSubmissions()
        {
            var subs = await _submissionRepository.GetAllSubmissions();

            var subResponseModel = new List<SubmissionResponseModel>();

            foreach (var sub in subs)
            {
                var candTemp = _submissionRepository.GetCandidateById(sub.CandidateId);
                subResponseModel.Add(new SubmissionResponseModel
                {
                    Id = sub.Id,
                    JobId = sub.JobId,
                    CandidateId = sub.CandidateId,
                    Email = candTemp.Result.Email,
                    FirstName = candTemp.Result.FirstName,
                    LastName = candTemp.Result.LastName,
                });
            }

            return subResponseModel;
        }
    }
}

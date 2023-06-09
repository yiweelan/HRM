﻿using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class InterviewService: IInterviewServcie
    {
        private readonly IInterviewRepository _interviewRepository;

        public InterviewService(IInterviewRepository interviewRepository)
        {
            _interviewRepository = interviewRepository;
        }

        public async Task<List<InterviewResponseModel>> GetAllInterviews()
        {
            var interviews = await _interviewRepository.GetAllInterviews();

            var interviewResponseModel = new List<InterviewResponseModel>();

            foreach (var interview in interviews)
            {
                interviewResponseModel.Add(new InterviewResponseModel()
                {
                    Id = interview.Id,
                    BeginTime = interview.BeginTime,
                    EndTime = interview.EndTime,
                    CandidateEmail = interview.CandidateEmail,
                    CandidateFirstName = interview.CandidateFirstName,
                    CandidateLastName = interview.CandidateLastName,
                    InterviewerId = interview.InterviewerId,
                    InterviewTypeId = interview.InterviewTypeId,
                    SubmissionId = interview.SubmissionId,
                });
            }

            return interviewResponseModel;
        }

        public async Task<InterviewResponseModel> GetInterviewsById(int id)
        {
            var interview = await _interviewRepository.GetInterviewById(id);
            if (interview == null)
            {
                return null;
            }

            var interviewResponseModel = new InterviewResponseModel
            {
                Id = interview.Id,
                BeginTime = interview.BeginTime,
                EndTime = interview.EndTime,
                CandidateEmail = interview.CandidateEmail,
                CandidateFirstName = interview.CandidateFirstName,
                CandidateLastName = interview.CandidateLastName,
                InterviewerId = interview.InterviewerId,
                InterviewTypeId = interview.InterviewTypeId,
                SubmissionId = interview.SubmissionId,
            };

            return interviewResponseModel;
        }

        public async Task<int> AddInterview(InterviewRequestModel model)
        {
            var interviewEntity = new Interview
            {
                CandidateIdentityId = Guid.NewGuid(),
                BeginTime = model.BeginTime,
                EndTime = model.EndTime,
                CandidateEmail = model.CandidateEmail,
                CandidateFirstName = model.CandidateFirstName,
                CandidateLastName = model.CandidateLastName,
                InterviewerId = model.InterviewerId,
                InterviewTypeId = model.InterviewTypeId,
                SubmissionId = model.SubmissionId,
            };

            var interivew = await _interviewRepository.AddAsync(interviewEntity);
            return interivew.Id;
        }

        public async Task<Interview> UpdateInterview(Interview entity)
        {
            var interview = await _interviewRepository.UpdateAsync(entity);
            return interview;
        }

        public async Task<int> DeleteInterview(int id)
        {
            var deletedId = await _interviewRepository.DeleteAsync(id);

            return deletedId;
        }

        public async Task<IEnumerable<InterviewResponseModel>> GetPaginatedInterviews(int pageSize = 30, int pageNumber = 1)
        {
            var interviews = await _interviewRepository.GetAllInterviews();

            interviews = interviews.OrderBy(x => x.BeginTime).ToList();

            pageNumber = pageNumber - 1;
            interviews = interviews.Skip(pageSize * pageNumber).Take(pageSize).ToList();

            var interviewResponseModel = new List<InterviewResponseModel>();

            foreach (var interview in interviews)
            {
                interviewResponseModel.Add(new InterviewResponseModel()
                {
                    Id = interview.Id,
                    BeginTime = interview.BeginTime,
                    EndTime = interview.EndTime,
                    CandidateEmail = interview.CandidateEmail,
                    CandidateFirstName = interview.CandidateFirstName,
                    CandidateLastName = interview.CandidateLastName,
                    InterviewerId = interview.InterviewerId,
                    InterviewTypeId = interview.InterviewTypeId,
                    SubmissionId = interview.SubmissionId,
                });
            }

            return interviewResponseModel;
        }
    }
}

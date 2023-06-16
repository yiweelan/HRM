using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Services;
using System.Linq.Expressions;
using Moq;
using NuGet.Frameworks;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Recruiting.UnitTests
{
    [TestClass]
    public class JobServiceUnitTest
    {
        private JobService _service;
        private static List<Job> _jobs;
        private Mock<IJobRepository> _mockRepository;

        [TestInitialize]
        public void OneTimeSetUp()
        {
           _mockRepository = new Mock<IJobRepository>();
            _service = new JobService(_mockRepository.Object);
            _mockRepository.Setup(j => j.GetAllJobs()).ReturnsAsync(_jobs);
        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _jobs = new List<Job>()
            {
                new Job{Id = 1, Description = "Java Dev 1", Title = "Junior",
                    StartDate = DateTime.UtcNow, NumberOfPositions = 2},
                new Job{Id = 2, Description = "Java Dev 2", Title = "Senior",
                    StartDate = DateTime.UtcNow, NumberOfPositions = 3},
                new Job{Id = 3, Description = "C# Dev 1", Title = "Junior",
                    StartDate = DateTime.UtcNow, NumberOfPositions = 1},
                new Job{Id = 4, Description = "Angular Dev 1", Title = "Junior",
                    StartDate = DateTime.UtcNow, NumberOfPositions = 3},
                new Job{Id = 5, Description = "Angular Dev 2", Title = "Senior",
                    StartDate = DateTime.UtcNow, NumberOfPositions = 3},
            };
        }

        [TestMethod]
        public async Task TestGetAllJobsFromFakeData()
        {
            //_service = new JobService(new MockJobRepository());
            
            //JobService => GetAllJobs

            var jobs = await _service.GetAllJobs();

            // Arrange, Act, Assert

            //Assert
            Assert.IsNotNull(jobs);
            Assert.AreEqual(jobs.Count, 5);
            Assert.IsInstanceOfType(jobs, typeof(List<JobResponseModel>));
            // Console.WriteLine("unit test success");
        }
    }

   
}
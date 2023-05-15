using ApplicationCore.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public class IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public IStatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
    }
}

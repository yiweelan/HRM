using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class InterviewsDbContext : DbContext
    {
        public InterviewsDbContext(DbContextOptions<InterviewsDbContext> options) : base(options)
        {

        }
    }
}

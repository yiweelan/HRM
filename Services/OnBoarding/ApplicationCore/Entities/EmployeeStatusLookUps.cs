using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class EmployeeStatusLookUps
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string EmployeeStatusCode { get; set; }

        [MaxLength(1024)]
        public string EmployeeStatusDescription { get; set; }
    }
}

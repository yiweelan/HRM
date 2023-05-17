using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class InterviewTypeLookUp
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string InterviewTypeCode { get; set; }
        [MaxLength(256)]
        public string InterviewTypeDescription { get; set; }
    }
}

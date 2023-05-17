using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class InterviewRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Interview Begin Time")]
        [DataType(DataType.Date)]
        public DateTime BeginTime { get; set; }
        [Required(ErrorMessage = "Please enter Interview Begin Time")]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Please enter Candidate Email")]
        public string CandidateEmail { get; set; }

        [Required(ErrorMessage = "Please enter Candidate First Name")]
        [StringLength(50)]
        public string CandidateFirstName { get; set; }

        [Required(ErrorMessage = "Please enter Candidate Last Name")]
        [StringLength(50)]
        public string CandidateLastName { get; set; }

        [Required(ErrorMessage = "Please enter InterviewerId")]
        public int InterviewerId { get; set; }
        [Required(ErrorMessage = "Please enter InterviewTypeId")]
        public int InterviewTypeId { get; set; }
        [Required(ErrorMessage = "Please enter SubmissionId")]
        public int SubmissionId { get; set; }
    }
}

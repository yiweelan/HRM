using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class SubmissionRequestModel
    {
        public int Id { get; set; }

        public int JobId { get; set; }
        public int CandidateId { get; set; }

        [Required(ErrorMessage = "Please enter Email of Submission")]
        [StringLength(512)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter First Name of Submission")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name of Submission")]
        [StringLength(50)]
        public string LastName { get; set; }

    }
}

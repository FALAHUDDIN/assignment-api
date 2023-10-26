using System.ComponentModel.DataAnnotations.Schema;

namespace IntelAssessmentAPI.Models.JobHistory
{
    public class JobHistory
    {
        public Guid Id { get; set; }

        [ForeignKey("Profile")]
        public Guid IdProfile { get; set; }

        public string? CompanyName { get; set; }

        public string? Position { get; set; }

        public string? Department { get; set; }

        public string? JobDescription { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Profile.Profile? Profile { get; set; }
    }
}

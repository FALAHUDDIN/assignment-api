using System.ComponentModel.DataAnnotations.Schema;

namespace IntelAssessmentAPI.Models.Education
{
    public class Education
    {
        public Guid Id { get; set; }

        [ForeignKey("Profile")]
        public Guid IdProfile { get; set; }

        public string? InstitutionName { get; set; }

        public string? EducationLevel { get; set; }

        public string? StudyField { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Profile.Profile? Profile { get; set; }
    }
}

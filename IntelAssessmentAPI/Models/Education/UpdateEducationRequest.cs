namespace IntelAssessmentAPI.Models.Education
{
    public class UpdateEducationRequest
    {
        public string? InstitutionName { get; set; }

        public string? EducationLevel { get; set; }

        public string? StudyField { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}

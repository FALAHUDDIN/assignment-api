namespace IntelAssessmentAPI.Models.JobHistory
{
    public class UpdateJobHistoryRequest
    {
        public string? CompanyName { get; set; }

        public string? Position { get; set; }

        public string? Department { get; set; }

        public string? JobDescription { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}

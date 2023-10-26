namespace IntelAssessmentAPI.Models.Detail
{
    public class UpdateDetailRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Gender? Gender { get; set; }

        public DateTime? DateBirth { get; set; }

        public string? PassportNo { get; set; }

        public string? Hobby { get; set; }

        public string? Address { get; set; }

        public string? PhoneNo { get; set; }

        public string? Skill { get; set; }

        public string? Pet { get; set; }

        public string? FreeTimeActivity { get; set; }

        public string? Interest { get; set; }

        public string? FavouriteFood { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }
    }
}

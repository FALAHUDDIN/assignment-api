using System.ComponentModel.DataAnnotations.Schema;

namespace IntelAssessmentAPI.Models.Detail
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Detail
    {
        public Guid Id { get; set; }

        [ForeignKey("Profile")]
        public Guid IdProfile { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Gender? Gender { get; set; }

        public DateTime? DateBirth { get; set; }

        public string? PassportNo { get; set; }

        public string? Address { get; set; }

        public string? PhoneNo { get; set; }

        public string? Hobby { get; set; }

        public string? Skill { get; set; }

        public string? Pet { get; set; }

        public string? FreeTimeActivity { get; set; }

        public string? Interest { get; set; }

        public string? FavouriteFood { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }

        public virtual Profile.Profile? Profile { get; set; }
    }
}
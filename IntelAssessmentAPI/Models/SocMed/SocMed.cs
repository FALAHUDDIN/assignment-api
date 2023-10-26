using System.ComponentModel.DataAnnotations.Schema;

namespace IntelAssessmentAPI.Models.SocMed
{
    public class SocMed
    {
        public Guid Id { get; set; }

        [ForeignKey("Profile")]
        public Guid IdProfile { get; set; }

        public string? NameOfMedia { get; set; }

        public string? UserName { get; set; }

        public virtual Profile.Profile? Profile { get; set; }
    }
}

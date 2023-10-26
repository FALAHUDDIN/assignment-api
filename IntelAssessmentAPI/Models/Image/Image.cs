using System.ComponentModel.DataAnnotations.Schema;

namespace IntelAssessmentAPI.Models.Image
{
    public class Image
    {
        public Guid Id { get; set; }

        [ForeignKey("Profile")]
        public Guid IdProfile { get; set; }

        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        public virtual Profile.Profile? Profile { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace IntelAssessmentAPI.Models.Biography
{
    public class Biography
    {
        public Guid Id { get; set; }

        [ForeignKey("Profile")]
        public Guid IdProfile { get; set; }

        public string? Summary1 { get; set; }

        public string? Summary2 { get; set; }

        public string? Summary3 { get; set; }

        public virtual Profile.Profile? Profile { get; set; }
    }
}

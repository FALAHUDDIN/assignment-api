
using System.ComponentModel.DataAnnotations;

namespace IntelAssessmentAPI.Models.Profile
{
    public class Profile
    {
        public Guid Id { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? NickName { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? ProfilePhoto { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Detail.Detail? Detail { get; set; }

        public virtual ICollection<JobHistory.JobHistory>? JobHistory { get; set; }

        public virtual ICollection<Education.Education>? Education { get; set; }

        public virtual ICollection<Biography.Biography>? Biography { get; set; }

        public virtual ICollection<SocMed.SocMed>? SocMed { get; set; }

        public virtual ICollection<Image.Image>? Image { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace IntelAssessmentAPI.Models.Profile
{
    public class AddProfileRequest
    {
        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? NickName { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? ProfilePhoto { get; set; }
    }
}

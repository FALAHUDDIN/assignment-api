using System.ComponentModel.DataAnnotations;

namespace IntelAssessmentAPI.Models.Profile
{
    public class UpdateProfileRequest
    {
        public string? FullName { get; set; }

        public string? NickName { get; set; }

        public string? Email { get; set; }

        public string? ProfilePhoto { get; set; }
    }
}

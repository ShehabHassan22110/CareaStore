namespace Carea.Models
{
    public class EditeProfileModel
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? username { get; set; }
        public IFormFile? Photo { get; set; }
        public string? FullName { get; set; }
        public string? NickName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NewPassword { get; set; }
        public string? OldPassword { get; set; }
        public bool? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? PIN { get; set; }

    }
}

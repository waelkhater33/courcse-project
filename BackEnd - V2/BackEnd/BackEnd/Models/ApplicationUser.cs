using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class ApplicationUser :IdentityUser
    {
        
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [JsonIgnore]
        public ICollection<UserCertificate> UserCertificates { get; set; }
        [JsonIgnore]
        public ICollection<UserCourse> UserCourses { get; set; }
    }
}

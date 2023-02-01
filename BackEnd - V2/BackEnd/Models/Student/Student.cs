using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StdId { get; set; }
        [MaxLength(50), Required]
        public string FirstName { get; set; }
        [MaxLength(50), Required]
        public string LastName { get; set; }
        [MaxLength(50), Required]
        public string StdUserName { get; set; }
        [MaxLength(50), Required]
        public string StdPassword { get; set; }

        public ICollection<StudentCertificate> StudentCertificates { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}


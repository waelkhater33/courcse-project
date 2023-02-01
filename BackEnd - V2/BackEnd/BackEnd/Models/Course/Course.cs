using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CrsId { get; set; }
        [ Required]
        public string Imagpath { get; set; }        
        [MaxLength(50), Required]
        public string CrsTitle { get; set; }
        [MaxLength(200)]
        public string CrsDesc { get; set; }
        [Required]
        public double Price { get; set; }
        [JsonIgnore]
        public virtual ICollection<Video> Videos { get; set; }
        [JsonIgnore]
        public ICollection<UserCourse> UserCourses { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    public class StudentCourse
    {
        public int ID { get; set; }
        [ForeignKey("Student")]
        public int StdId { get; set; }
        [JsonIgnore]
        public  virtual Student Student { get; set; }
        [ForeignKey("Course")]
        public int CrsID { get; set; }
        [JsonIgnore]
        public virtual Course Course { get; set; }
    }
}

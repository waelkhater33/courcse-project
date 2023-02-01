using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    public class UserCourse    
    {
        public int ID { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("Course")]
        public int CrsID { get; set; }
        [JsonIgnore]
        public virtual Course Course { get; set; }
    }
}

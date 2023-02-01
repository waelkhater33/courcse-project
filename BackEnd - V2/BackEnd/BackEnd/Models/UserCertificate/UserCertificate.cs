using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class UserCertificate
    {
        public int ID { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        [ForeignKey("certificate")]
        public int CertID { get; set; }

        public Certificate certificate { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}

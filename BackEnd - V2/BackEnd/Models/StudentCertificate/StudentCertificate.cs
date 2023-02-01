using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class StudentCertificate
    {
        public int ID { get; set; }
        [ForeignKey("student")]
        public int StudentID { get; set; }
        [ForeignKey("certificate")]
        public int CertID { get; set; }

        public Certificate certificate { get; set; }
        public Student student { get; set; }
    }
}

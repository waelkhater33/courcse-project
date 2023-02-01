namespace BackEnd.Models
{
    public class CourseWithVideoInstructorUserDTO
    {
        public int CrsID { get; set; }
        public string imagpath { get; set; }
        public string CrsTitle { get; set; }
        public string CrsDesc { get; set; }
        public string UserID { get; set; }
        public double  Price { get; set; }
        public string VideoName { get; set; }
        public string URL { get; set; }

    }
}

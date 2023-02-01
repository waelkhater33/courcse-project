namespace BackEnd.Models.DTO
{
    public class UserCourseCourseDTO
    {
        public int CrsID { get; set; }
        public string imagpath { get; set; }
        public string CrsTitle { get; set; }
        public string CrsDesc { get; set; }
        public string UserID { get; set; }
        public double Price { get; set; }
        public List<UserCourse> UserCourses { get; set; }
    }
}

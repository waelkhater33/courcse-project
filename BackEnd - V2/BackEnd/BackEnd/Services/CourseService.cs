using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models.DTO;
using System.Linq;

namespace BackEnd.Services
{
    public class CourseService
    {
        private readonly ProjectContext ctx;

        public CourseService(ProjectContext projectContext)
        {
            ctx = projectContext;
        }

        public List<Course> GetService()
        {
            return ctx.Courses.ToList();
            

        }
        public Course SelectByNameService(string name)
        {
            return ctx.Courses.FirstOrDefault(c => c.CrsTitle == name);
        }
        public List<Course> GetByUserID( string userID)
        {
            var userCourses = ctx.UserCourses.Where(ctx => ctx.UserID == userID).ToList();
            List<Course> courses = new List<Course>();
            foreach(var course in userCourses)
            {
                var crs = ctx.Courses.FirstOrDefault(c => c.CrsId == course.CrsID);
                courses.Add(crs);
            }
            return courses;
        }
        public int AddServiceForInstructor(CourseWithVideoInstructorUserDTO crsDTO)
        {
            var courses = new Course();
            var userCourse = new UserCourse();
            var videos = new Video();
            courses.CrsId = crsDTO.CrsID;
            courses.Imagpath=crsDTO.imagpath;
            courses.CrsTitle = crsDTO.CrsTitle;
            courses.CrsDesc = crsDTO.CrsDesc;
            courses.Price = crsDTO.Price;
            ctx.Courses.Add(courses);
            ctx.SaveChanges();
            videos.CrsId = courses.CrsId;
            videos.Name = crsDTO.VideoName;
            videos.Url = crsDTO.URL;
            ctx.Videos.Add(videos);
            ctx.SaveChanges();
            userCourse.UserID = crsDTO.UserID;
            userCourse.CrsID = courses.CrsId;
            ctx.UserCourses.Add(userCourse);
            ctx.SaveChanges();
            
            return 1;
        }

        public int AssignCourse(UserCourse userCourse)
        {
            var user = new UserCourse();
            user.CrsID = userCourse.CrsID;
            user.UserID = userCourse.UserID;
            ctx.UserCourses.Add(user);
            ctx.SaveChanges();
            return 1;
        }
        public int AddUserCourse(UserCourseDTO userCrs)
        {
            var userCourse = new UserCourse();
            userCourse.UserID = userCrs.UserID;
            userCourse.CrsID = userCrs.CrsID;
            ctx.UserCourses.Add(userCourse);
            ctx.SaveChanges();
            return 1;
        }

        public void UpdateService(int id, UserCourseCourseDTO newCourse, string userID)
        {
            if (newCourse.UserID == userID)
            {
                var currentCourse = ctx.Courses.FirstOrDefault(c => c.CrsId == id);
                currentCourse.Imagpath = newCourse.imagpath;
                currentCourse.CrsTitle = newCourse.CrsTitle;
                currentCourse.CrsDesc = newCourse.CrsDesc;
                ctx.SaveChanges();
            }
        }
    }
}

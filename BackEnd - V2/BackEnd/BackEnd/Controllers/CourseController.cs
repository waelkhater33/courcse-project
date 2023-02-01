using BackEnd.Models.DTO;
using BackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService courseService;
        private readonly ProjectContext projectContext;

        public CourseController(CourseService courseService, ProjectContext projectContext)
        {
            this.courseService = courseService;
            this.projectContext = projectContext;
        }


        [HttpGet]
        [Route("/Course/Get")]
        public IActionResult Get()
        {
            var course = courseService.GetService();
                return Ok(course);
        }

        [HttpGet]
        public IActionResult GetByUserID(string userID)
        {
            var crs = new UserCourseCourseDTO();
            var course = courseService.GetByUserID(userID);
            return Ok(course);
        }

        [HttpGet("/Course/Get/{name:alpha}")]
        public IActionResult SelectCourseByName(string name)
        {
            var crs = courseService.SelectByNameService(name);
            if (crs == null)
                return BadRequest("Name Not Found");
            return Ok(crs);
        }

        [HttpPost("/Course/AddByInsID/")]
        //[Authorize(Roles = "Instructor")]
        public IActionResult Add(CourseWithVideoInstructorUserDTO courses)
        {
            if (ModelState.IsValid)
            {
                var crs = courseService.AddServiceForInstructor(courses);
                //string url = Url.Link("SelectEmployeesByIDRoute", new { id = courses.CrsID });
                return Ok(crs);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult AddUserCourse(UserCourseDTO userCrs)
        {
            if (ModelState.IsValid)
            {
                var crs = courseService.AddUserCourse(userCrs);
                return Ok(crs);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("/Assign")]
        public IActionResult AssignCourse(UserCourse userCourse)
        {
            if (ModelState.IsValid)
            {
                var crs = courseService.AssignCourse(userCourse);
                return Ok(crs);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("/Course/Update/ID")]
        public IActionResult Update([FromRoute] int id, [FromBody] UserCourseCourseDTO NewCourse, string userID)
        {
            if (ModelState.IsValid)
            {
                courseService.UpdateService(id, NewCourse, userID);
                return StatusCode(StatusCodes.Status204NoContent, "Current Data Updated");
            }
            return BadRequest("Invalid Data");
        }

        
    }
}

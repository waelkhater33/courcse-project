using BackEnd.Models.DTO;
using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly VideoService videoService;
        private readonly ProjectContext projectContext;

        public VideoController(VideoService videoService, ProjectContext projectContext)
        {
            this.videoService = videoService;
            this.projectContext = projectContext;
        }

        [HttpGet("/Video/Get/ID")]

        public IActionResult Get(int id)
        {
            var video = videoService.GetService(id);
            if (video == null)
                return BadRequest("Video Not Found");
            return Ok(video);
        }

        [HttpPost("/Video/Add")]

        public IActionResult Add(VidoeWithCourse video)
        {
            if (ModelState.IsValid)
            {
                var vid = videoService.AddService(video);
                return Ok(vid);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("/Video/Update/ID")]
        public IActionResult Update([FromRoute] int id, [FromBody] VidoeWithCourse video)
        {
            if (ModelState.IsValid)
            {
                videoService.UpdateService(id, video);
                return StatusCode(StatusCodes.Status204NoContent, "Current Video Updated");
            }
            return BadRequest("Invalid Data");
        }

        [HttpDelete("/Video/Delete/ID")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                videoService.DeleteService(id);
                return StatusCode(StatusCodes.Status204NoContent, "Video Deleted Successfully");
            }
            return BadRequest("No Data To Be Deleted");

        }
    }
}

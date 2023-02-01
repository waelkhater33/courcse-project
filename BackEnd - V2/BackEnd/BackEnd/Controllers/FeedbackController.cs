using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet("/Feedback/Get/ID")]
        public IActionResult Get(int id)
        {
            var fdb = feedbackService.GetService(id);
            return Ok(fdb);
        }

        [HttpPost("/Feedback/Add/ID")]
        public IActionResult Add(int id,Feedback fdb)
        {
            if (ModelState.IsValid)
            {
                var feed = feedbackService.AddService(id, fdb);
                return Ok(feed);
            }
            return BadRequest(ModelState);
        }
    }
}

using BackEnd.Models.DTO;

namespace BackEnd.Services
{
    public class VideoService
    {
        private readonly ProjectContext ctx;

        public VideoService(ProjectContext projectContext)
        {
            ctx = projectContext;
        }

        public List<Video> GetService(int id)
        {
            return ctx.Videos.Where(i => i.CrsId == id).ToList();
        }

        public Video AddService(VidoeWithCourse video)
        {
            var vid = new Video();
            vid.Url = video.URL;
            vid.CrsId = video.CrsID;
            vid.Name = video.Name;


            ctx.Videos.Add(vid);
            ctx.SaveChanges();
            return vid;
        }

        public void UpdateService(int id, VidoeWithCourse newVideo)
        {
            var currentVideo = ctx.Videos.FirstOrDefault(i => i.ID == id);
            currentVideo.Url = newVideo.URL;
            currentVideo.CrsId = newVideo.CrsID;
            currentVideo.Name  = newVideo.Name;
        }

        public void DeleteService(int id)
        {
            var currentVideo = ctx.Videos.FirstOrDefault(ctx => ctx.ID == id);
            ctx.Videos.Remove(currentVideo);
            ctx.SaveChanges();
        }


    }
}

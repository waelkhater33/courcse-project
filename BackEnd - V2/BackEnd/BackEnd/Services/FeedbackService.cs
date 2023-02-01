namespace BackEnd.Services
{
    public class FeedbackService
    {
        private readonly ProjectContext ctx;

        public FeedbackService(ProjectContext projectContext)
        {
            ctx = projectContext;
        }

        public Feedback GetService(int id)
        {
            return ctx.Feedbacks.Where(f => f.CrsID == id).FirstOrDefault();
        }

        public Feedback AddService(int id, Feedback feedback)
        {
            var fdb = new Feedback();
            fdb.CrsID = feedback.CrsID;
            fdb.Content = feedback.Content;
            ctx.Feedbacks.Add(fdb);
            ctx.SaveChanges();
            return fdb;
        }
    }
}

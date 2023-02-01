namespace BackEnd.Services
{
    public class StudentCertificateService
    {
        private readonly ProjectContext ctx;
        public StudentCertificateService(ProjectContext projectContext)
        {
            ctx = projectContext;
        }

        public object GetService(string userID)
        {
            return ctx.UserCertificates.Where(i => i.UserID == userID);
        }


        public object AddService(UserCertDTO stdCert)
        {
            var stdCertificate = new UserCertificate();
            stdCertificate.CertID = stdCert.CertID;
            stdCertificate.UserID = stdCert.UserID;
            ctx.UserCertificates.Add(stdCertificate);
            ctx.SaveChanges();
            return stdCertificate;
        }


    }
}

namespace BackEnd.Services
{
    public class CertificateService
    {
        private readonly ProjectContext ctx;

        public CertificateService(ProjectContext projectContext)
        {
            ctx = projectContext;
        }

        public Certificate GetService(int id)
        {
            return ctx.Certificates.Where(c => c.CrsID == id).FirstOrDefault();
        }

        public Certificate AddService(CertificateDTO certificate)
        {
            var cert = new Certificate();
            cert.CrsID = certificate.CrsID;
            cert.date = certificate.Date;
            cert.Name = certificate.Name;
            ctx.Certificates.Add(cert);
            ctx.SaveChanges();
            return cert;
        }
    }
}

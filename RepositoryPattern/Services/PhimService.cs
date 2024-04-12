using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Services
{
    public class PhimService
    {
        WebphimonlineContext db = new WebphimonlineContext();
        IPhimRepository pRepo = null;
        public PhimService(IPhimRepository prp)
        {
            pRepo = prp;
        }
        public enum status
        {
            existed,
            created
        }
        public status Create(Phim req) {
            var check = db.Phims.FirstOrDefault(x=>x.TenPhim ==req.TenPhim);
            if (check == null)
            {
                pRepo.Add(req);
                return status.created;
            }else { return status.existed; }
        }
    }
}

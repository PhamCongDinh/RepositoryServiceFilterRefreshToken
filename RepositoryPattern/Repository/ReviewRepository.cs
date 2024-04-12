using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class ReviewRepository : IGenericRepository<Danhgia>
    {
        WebphimonlineContext db = new WebphimonlineContext();
        public void Add(Danhgia req)
        {
            req.ThoiGian = DateTime.Now;
            db.Danhgia.Add(req);
            db.SaveChanges();
        }

        public void Delete(Danhgia req)
        {
            throw new NotImplementedException();
        }

        public Danhgia GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<Danhgia> Getdatas()
        {
            throw new NotImplementedException();
        }

        public Danhgia Update(Danhgia req)
        {
            throw new NotImplementedException();
        }
    }
}

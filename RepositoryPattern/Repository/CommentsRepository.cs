using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class CommentsRepository : IGenericRepository<Binhluan>
    {
        WebphimonlineContext db = new WebphimonlineContext();
        public void Add(Binhluan req)
        {
            req.ThoiGian = DateTime.Now;
            db.Binhluans.Add(req);
            db.SaveChanges();
        }

        public void Delete(Binhluan req)
        {
            throw new NotImplementedException();
        }

        public Binhluan GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<Binhluan> Getdatas()
        {
            throw new NotImplementedException();
        }

        public Binhluan Update(Binhluan req)
        {
            throw new NotImplementedException();
        }
    }
}

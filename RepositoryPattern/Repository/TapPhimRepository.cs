using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class TapPhimRepository : IGenericRepository<Tapphim>
    {
        WebphimonlineContext db = new WebphimonlineContext();   
        public void Add(Tapphim req)
        {
            db.Tapphims.Add(req);
            db.SaveChanges();
        }

        public void Delete(Tapphim req)
        {
            db.Tapphims.Remove(req);
            db.SaveChanges();
        }

        public Tapphim GetById(int Id)
        {
            return db.Tapphims.FirstOrDefault(x => x.Id == Id);

        }

        public IList<Tapphim> Getdatas()
        {
            throw new NotImplementedException();
        }

        public Tapphim Update(Tapphim req)
        {
            throw new NotImplementedException();
        }

        
    }
}

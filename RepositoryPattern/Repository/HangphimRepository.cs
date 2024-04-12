using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class HangphimRepository : IGenericRepository<Hangphim>
    {
        WebphimonlineContext db = new WebphimonlineContext();
        public void Add(Hangphim req)
        {
            db.Hangphims.Add(req);
            db.SaveChanges();
        }

        public void Delete(Hangphim req)
        {
            db.Hangphims.Remove(req);
            db.SaveChanges();
        }

        public Hangphim GetById(int Id)
        {
            return db.Hangphims.FirstOrDefault(x=>x.Id==Id);
        }

        public IList<Hangphim> Getdatas()
        {
            return db.Hangphims.ToList();
        }

        public Hangphim Update(Hangphim req)
        {
            var hp = db.Hangphims.Attach(req);
            hp.State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return req;
        }
    }
}

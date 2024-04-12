using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class PhimRepository : IPhimRepository
    {
        WebphimonlineContext db = new WebphimonlineContext();
        public void Add(Phim phim)
        {
            db.Add(phim);
            db.SaveChanges();
        }

        public void Delete(Phim phim)
        {
            db.Phims.Remove(phim);
            db.SaveChanges();
        }

        public Phim GetPhimById(int phimId)
        {
            return db.Phims.Find(phimId);
        }

        public IList<Phim> GetPhims()
        {
            return db.Phims.ToList();
        }

        public Phim Update(Phim phim)
        {
            var film = db.Phims.Attach(phim);
            film.State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return phim;
        }
    }
}

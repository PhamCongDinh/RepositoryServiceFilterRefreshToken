using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class LoaiPhimRepository : IGenericRepository<Loaiphim>
    {
        WebphimonlineContext db = new WebphimonlineContext();
        public void Add(Loaiphim req)
        {
            db.Loaiphims.Add(req);
            db.SaveChanges();
        }

        public void Delete(Loaiphim req)
        {
            db.Loaiphims.Remove(req);
            db.SaveChanges();
        }

        public Loaiphim GetById(int Id)
        {
            return db.Loaiphims.FirstOrDefault(x => x.Id == Id);
        }

        public IList<Loaiphim> Getdatas()
        {
            return db.Loaiphims.ToList();
        }

        public Loaiphim Update(Loaiphim req)
        {
            var hp = db.Loaiphims.Attach(req);
            hp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return req;
        }
    }
}

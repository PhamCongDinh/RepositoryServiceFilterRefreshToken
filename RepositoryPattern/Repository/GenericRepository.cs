
using RepositoryPattern.Models;
using System.Linq;
namespace RepositoryPattern.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        WebphimonlineContext db = new WebphimonlineContext();
        
        public void Add(T req)
        {
            db.Add(req);
            db.SaveChanges();
        }

        public void Delete(T req)
        {
            db.Remove(req);
            db.SaveChanges();
        }

        public T GetById(int Id)
        {

            return db.Set<T>().Find(Id);
        }

        public IList<T> Getdatas()
        {
            throw new NotImplementedException();
        }

        public T Update(T req)
        {
            var update = db.Set<T>().Update(req);
            update.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return req;
        }
    }
}

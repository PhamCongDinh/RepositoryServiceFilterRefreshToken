using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public IList<T> Getdatas();
        public T GetById(int Id);
        public void Add(T req);
        public T Update(T req);
        public void Delete(T req);
    }
    
   
}

using RepositoryPattern.Repository;

namespace RepositoryPattern.Services
{
    public class GenericService<T> where T : class
    {
        IGenericRepository<T> _repo;
        public GenericService(IGenericRepository<T> repo)
        {
            _repo = repo;
        }

        public T add(T req)
        {
            _repo.Add(req);
            return req;
        }

        public T update(T req)
        {
            _repo.Update(req);
            return req;
        }
        public void delete(T req)
        {
            _repo.Delete(req);
        }
        public T getbyid(int id)
        {
            var lst =_repo.GetById(id);
            return lst;
        }
    }
}

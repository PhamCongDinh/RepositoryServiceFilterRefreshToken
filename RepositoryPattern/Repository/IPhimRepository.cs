using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public interface IPhimRepository
    {
        public IList<Phim> GetPhims();
        public Phim GetPhimById(int phimId);
        public void Add(Phim phim);
        public Phim Update(Phim phim);
        public void Delete(Phim phim);
    }
}

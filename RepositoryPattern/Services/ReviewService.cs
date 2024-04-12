using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Services
{
    public class ReviewService
    {
        IGenericRepository<Danhgia> _rvrepo;
        public ReviewService(IGenericRepository<Danhgia> rvrepo)
        {
            _rvrepo = rvrepo;
        }
        public Danhgia newreview(Danhgia req)
        {
            _rvrepo.Add(req);
            return req;
        }
    }
}

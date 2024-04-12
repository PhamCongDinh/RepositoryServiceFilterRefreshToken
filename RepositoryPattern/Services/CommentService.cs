using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Services
{
    public class CommentService
    {
        IGenericRepository<Binhluan> _cmmtRepo;
        public CommentService(IGenericRepository<Binhluan> cmmtRepo)
        {
            _cmmtRepo = cmmtRepo;
        }   

        public Binhluan newcmmt(Binhluan req)
        {
            _cmmtRepo.Add(req);
            return req;
        }
    }
}

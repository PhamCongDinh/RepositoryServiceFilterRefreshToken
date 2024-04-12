using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public interface IAuthenRepository
    {
        public IList<Taikhoan> GetTaikhoan();
        public Taikhoan GetTaikhoan(string email, string pass);
        public Taikhoan GetTKbyMail(string email);
        public void Add(Taikhoan req);
        public Taikhoan Update(Taikhoan req);
        public void Delete(int id);
    }
}

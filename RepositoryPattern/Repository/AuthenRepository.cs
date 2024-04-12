using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class AuthenRepository : IAuthenRepository
    {
        WebphimonlineContext db = new WebphimonlineContext();   
        public void Add(Taikhoan req)
        {
            db.Taikhoans.Add(req);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Taikhoans.Remove(db.Taikhoans.Find(id));
            db.SaveChanges();
        }

        public IList<Taikhoan> GetTaikhoan()
        {
            throw new NotImplementedException();
        }

        public Taikhoan GetTaikhoan(string email, string pass)
        {
            var user = db.Taikhoans.FirstOrDefault(x=>x.Email==email && x.MatKhau==pass);
            return user;
        }

        public Taikhoan GetTKbyMail(string email)
        {
            var check = db.Taikhoans.FirstOrDefault(x => x.Email == email);
            return check;
        }

        public Taikhoan Update(Taikhoan req)
        {
            var hp = db.Taikhoans.Attach(req);
            hp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return req;
        }
    }
}

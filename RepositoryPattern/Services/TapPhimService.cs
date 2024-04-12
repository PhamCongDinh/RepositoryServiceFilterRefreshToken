using RepositoryPattern.Models;
using RepositoryPattern.Models.Req;
using System.Threading.Tasks;

namespace RepositoryPattern.Services
{
    public class TapPhimService
    {


        WebphimonlineContext db = new WebphimonlineContext();
        public TapPhimService() { }

        public Tapphim DoubleCheck(int idPhim, int tapso)
        {
            var check = db.Tapphims.FirstOrDefault(x => x.IdPhim == idPhim && x.TapSo == tapso);
            return check;
        }


        
    }
}

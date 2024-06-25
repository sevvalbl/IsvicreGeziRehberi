using IsvicreGeziRehberi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace IsvicreGeziRehberi.Controllers
{
    public class GirisYapController : Controller
    {
        private readonly DatabaseContext _context;

        public GirisYapController(DatabaseContext context)
        {
            _context = context;
        }
        //GET
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string mail, string sifre)
        {
            try
            {
                var kullanici = _context.Kullanicis.FirstOrDefault(x => x.Email == mail && x.Sifre == sifre && x.AktiflikDurumu);
                if (kullanici != null) { 
                
                

                    if (kullanici.RolID == 1)
                    {
                        return Redirect("/Admin/Kullanici");
                    }
                    else
                    {
                        return Redirect("/Home");
                    }
                }
            }

            catch (Exception errorMessage)
            {

                TempData["Mesaj"] = "Giriş yapılamadı!";
            }

            return View();
        }
    }
}

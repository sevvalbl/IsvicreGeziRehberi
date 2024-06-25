using IsvicreGeziRehberi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsvicreGeziRehberi.Controllers
{
    public class KaydolController : Controller
    {
        private readonly DatabaseContext _context;

        public KaydolController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Index(string ad, string soyad, string sifre, string mail, Kullanici kullanici)
            {



                 kullanici.Ad = ad;
                 kullanici.Soyad = soyad;
                 kullanici.Email = mail;
                 kullanici.Sifre = sifre;
                 kullanici.AktiflikDurumu = true;
            
                kullanici.KayitTarihi = DateTime.Now;
                kullanici.RolID = 0;

                _context.Add(kullanici);
                await _context.SaveChangesAsync();
                return Redirect("/Home");







            }





           
      
    
    }
}




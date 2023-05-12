using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;
using VeritabanıProje.Models;

namespace VeritabanıProje.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(bool? logout)
        {
            return View();
        }
        public async Task<IActionResult> login(Admin a)
        {
            var admin = c.admins.FirstOrDefault(x => x.username == a.username && x.password == a.password);
            if (admin != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.username),
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Dashboard", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home", new { logout = true });
        }
        [Authorize]
        public async Task<IActionResult> Dashboard(bool? logout)
        {

            var sirketler = c.sirkets.ToList();
            var ziyaretciler = c.ziyaretcis.ToList();
            var fuarlar = c.fuars.ToList();
            var standlar = c.stands.ToList();
            var sektorler = c.sektors.ToList();
            ViewData["Sirketler"] = sirketler;
            ViewData["Ziyaretciler"] = ziyaretciler;
            ViewData["Fuarlar"] = fuarlar;
            ViewData["Standlar"] = standlar;
            ViewData["Sektorler"] = sektorler;

            if (logout.HasValue && logout.Value)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Fuarlar()
        {
            var fuarlar = c.fuars.ToList();
            return View(fuarlar);
        }
        public IActionResult Sirketler()
        {
            var sirketler = c.sirkets.ToList();
            return View(sirketler);
        }
        public IActionResult Standlar()
        {
            var standlar = c.stands.Where(x => x.sirket_ != null).ToList();
            return View(standlar);
        }
        public IActionResult Ziyaretciler()
        {
            var ziyaretciler = c.ziyaretcis.ToList();
            return View(ziyaretciler);
        }
        public IActionResult Sektorler()
        {
            var sektorler = c.sektors.ToList();
            return View(sektorler);
        }
        public IActionResult StandEkle(Stand s, int sId)
        {
            var stand = c.stands.OrderByDescending(x => x.Id).Take(1).Where(w => w.fuar_isim == s.fuar_isim).FirstOrDefault();
            var sirket = c.sirkets.FirstOrDefault(x => x.Id == sId);
            var fuar = c.fuars.FirstOrDefault(f => f.isim == sirket.fuar_isim);
            if (stand != null)
            {
                int count = c.stands.Count(x => x.fuar_isim == s.fuar_isim && x.salon_no == stand.salon_no) + 1;
                if (stand.salon_no <= 1 && count + 1 <= 5)
                {
                    s.salon_no = 1;
                    s.stand_no = count + 1;
                    s.sirket_ = c.sirkets.FirstOrDefault(x => x.Id == sId);
                    s.sirket_isim = c.sirkets.FirstOrDefault(x => x.Id == sId).isim;
                    s.fuar_ = fuar;
                    s.fuar_isim = fuar.isim;
                    c.stands.Add(s);
                    c.SaveChanges();
                    sirket.salon_no = 1;
                    sirket.stand_no = s.stand_no;
                    sirket.onay = true;
                    c.sirkets.Update(sirket);
                    c.SaveChanges();

                }
                else if (count + 1 > 5 && count + 1 <= 10)
                {
                    s.salon_no = 2;
                    s.stand_no = count - 5;
                    s.sirket_ = c.sirkets.FirstOrDefault(x => x.Id == sId);
                    s.sirket_isim = c.sirkets.FirstOrDefault(x => x.Id == sId).isim;
                    s.fuar_ = fuar;
                    s.fuar_isim = fuar.isim;
                    c.stands.Add(s);
                    c.SaveChanges();
                    sirket.salon_no = 2;
                    sirket.stand_no = s.stand_no;
                    sirket.onay = true;
                    c.sirkets.Update(sirket);
                    c.SaveChanges();
                }
                else
                {
                    TempData["ErrorMessage"] = "Şuanda Boş Stand Bulunmamakta";
                    return RedirectToAction("Sirketler", "Home");
                }
            }
            else
            {
                s.salon_no = 1;
                s.stand_no = 1;
                s.sirket_ = c.sirkets.FirstOrDefault(x => x.Id == sId);
                s.sirket_isim = c.sirkets.FirstOrDefault(x => x.Id == sId).isim;
                s.fuar_ = fuar;
                s.fuar_isim = fuar.isim;
                c.stands.Add(s);
                c.SaveChanges();
                sirket.salon_no = 1;
                sirket.stand_no = s.stand_no;
                sirket.onay = true;
                c.sirkets.Update(sirket);
                c.SaveChanges();
            }
            return RedirectToAction("Standlar", "Home");
        }
        public IActionResult SektorSil(int sId)
        {
            var sektor = c.sektors.FirstOrDefault(x => x.Id == sId);
            c.sektors.Remove(sektor);
            c.SaveChanges();
            return RedirectToAction("Sektorler", "Home");
        }
        public void TarihGüncelleme()
        {
            var tarih = c.fuars.Where(x => x.tarih < DateTime.Now).ToList();
            foreach (var t in tarih)
            {
                t.aktif = false;
            }
            c.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VeritabanıProje.Models;

namespace VeritabanıProje.Controllers
{
	public class CompanyController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var sektorler = c.sektors.ToList();
            ViewData["Sektorler"] = sektorler;
            return View();
        }
        public async Task<IActionResult> GoBack()
        {
            return RedirectToAction("Stand/Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(Sirket d, int sektorId)
        {
            var sektor = c.sektors.FirstOrDefault(f => f.Id == sektorId);
            var fuar = c.fuars.FirstOrDefault(f => f.sektor == sektor);
            d.sektor_ = sektor;
            d.sektor_adı = sektor.isim;
            d.fuar_ = fuar;
            d.fuar_isim = fuar.isim;
            c.sirkets.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index", "Stand");

        }
    }
}

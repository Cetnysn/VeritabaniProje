using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using VeritabanıProje.Models;

namespace VeritabanıProje.Controllers
{
    public class VisitorController : Controller
    {
        Context c = new Context();
        public async Task<IActionResult> Index()
        {
            var fuarlar = c.fuars.Where(x => x.aktif == true).ToList();
            ViewData["Fuarlar"] = fuarlar;
            return View();
        }

        public async Task<IActionResult> GoBack()
        {
            return RedirectToAction("Stand/Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisitor(Ziyaretci z, int fId)
        {
            var fuar = c.fuars.FirstOrDefault(f => f.Id == fId);
            z.fuar = fuar;
            z.fuar_adı = fuar.isim;
            c.ziyaretcis.Add(z);
            c.SaveChanges();
            return RedirectToAction("Index", "Stand");

        }

    }
}

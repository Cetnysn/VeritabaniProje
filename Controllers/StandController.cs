using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using VeritabanıProje.Models;

namespace VeritabanıProje.Controllers
{
    public class StandController : Controller
	{
		Context c = new Context();
		public async Task<IActionResult> Index()
		{
			var fuarlar = c.fuars.Where(x => x.aktif == true).ToList();
			return View(fuarlar);
		}

	}
}

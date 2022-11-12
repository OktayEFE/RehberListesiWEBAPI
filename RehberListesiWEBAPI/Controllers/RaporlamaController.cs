using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RehberListesiWEBAPI.Models.Context;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RehberListesiWEBAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class RaporlamaController : Controller
    {
		private readonly Context _context;

		public RaporlamaController(Context context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult KonumBilgisi()
		{
			var KonumListesi = _context.IletisimBilgileris.GroupBy(x => x.Konum).Select(x => x.Key).ToList();
			var sonuc = from item in KonumListesi
						select new
						{
							Konum = item,
							KisiSayisi = _context.IletisimBilgileris.Where(x => x.Konum == item).Count(),
							TelefonNumarasi = _context.IletisimBilgileris.Where(x => x.Konum == item && x.TelefonNumarasi != "").Count()
						};
			return Ok(sonuc);
		}
    }
}


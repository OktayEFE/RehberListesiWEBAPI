using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RehberListesiWEBAPI.Models;
using RehberListesiWEBAPI.Models.Context;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RehberListesiWEBAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class IletisimBilgileriController : Controller
    {
		private readonly Context _context;

		public IletisimBilgileriController(Context context)
		{
			_context = context;
		}
		[HttpPost]
		public IActionResult IletisimbilgisiKaydet([FromBody] IletisimBilgileri iletisimBilgileri)
		{
			try
			{
				_context.IletisimBilgileris.Add(iletisimBilgileri);
				_context.SaveChanges();
				return Ok("İletişim Bilgileri Kayıt İşlemi Başarılı");
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
			
		}
		[HttpDelete("{id}")]
		public IActionResult IletisimBilgisiSilme(int id)
		{
			try
			{
				IletisimBilgileri iletisimBilgileri = _context.IletisimBilgileris.Find(id);
				_context.IletisimBilgileris.Remove(iletisimBilgileri);
				return Ok("Silme İşlemi Tamamlandı");
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
			
		}
	}
}


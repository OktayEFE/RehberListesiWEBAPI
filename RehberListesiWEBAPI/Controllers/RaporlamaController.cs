using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RehberListesiWEBAPI.Models.Context;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RehberListesiWEBAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class RaporlamaController : Controller
    {
		private readonly Context _context;
		private readonly string bootstrapServers = "localhost:9092";
		private readonly string topic = "Raporlama";

		public RaporlamaController(Context context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> KonumBilgisi()
		{
			var KonumListesi = _context.IletisimBilgileris.GroupBy(x => x.Konum).Select(x => x.Key).ToList();
			if (KonumListesi == null)
			{
				return NotFound();
			}
			var sonuc = from item in KonumListesi
						select new
						{
							Konum = item,
							KisiSayisi = _context.IletisimBilgileris.Where(x => x.Konum == item).CountAsync(),
							TelefonNumarasiSayisi = _context.IletisimBilgileris.Where(x => x.Konum == item && x.TelefonNumarasi != "").Count(),
							RaporlamaTalepTarihi = DateTime.Now.ToString()
						};
			string message = JsonSerializer.Serialize(sonuc);
			return Ok(await SendOrderRequest(topic,message));
		}

		private async Task<bool> SendOrderRequest
		(string topic, string message)
		{
			ProducerConfig config = new ProducerConfig
			{
				BootstrapServers = bootstrapServers,
				ClientId = Dns.GetHostName()
			};

			try
			{
				using (var producer = new ProducerBuilder
				<Null, string>(config).Build())
				{
					var result = await producer.ProduceAsync
					(topic, new Message<Null, string>
					{
						Value = message
					});

					Debug.WriteLine($"Gönderilen Zaman:{result.Timestamp.UtcDateTime.AddHours(3)}");
					return await Task.FromResult(true);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Hata Mesajı: {ex.Message}");
			}

			return await Task.FromResult(false);
		}

	}
}


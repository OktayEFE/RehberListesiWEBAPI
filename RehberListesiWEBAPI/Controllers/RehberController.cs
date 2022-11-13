using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RehberListesiWEBAPI.Models;
using RehberListesiWEBAPI.Models.Context;
using RehberListesiWEBAPI.Models.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RehberListesiWEBAPI.Controllers
{
	[Route("api/[controller]/[action]")]
    [ApiController]
	public class RehberController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
		private readonly string bootstrapServers = "localhost:9092";
		private readonly string topic = "RehberService";

		public RehberController(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet("{id}")]//localhost:7241/api/rehber/KisiBilgileri/1
        public IActionResult KisiBilgileri(int id)
        {
			try
			{
				List<Rehber> rehbers = _context.Rehbers.Include(x => x.IletisimBilgileris).Where(x=>x.RehberID==id).ToList();
				if (rehbers == null)
				{
					return NotFound();
				}
				return Ok(rehbers);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
			
        }
		[HttpGet]// localhost:7241/api/rehbber/RehberListesi
		public IActionResult RehberListesi()
        {
            try
            {
				List<Rehber> rehbers = _context.Rehbers.Include(x => x.IletisimBilgileris).ToList();
				if (rehbers == null)
				{
					return NotFound();
				}
				return Ok(rehbers);
			}
            catch (Exception ex)
            {
                return NotFound(ex.Message);
			}
            
        }
        //Rehber kayıt işlemi gerçekleşiyor, sadece rehber bilileri geleceği için RehberDTO kullanıldı.
        [HttpPost]// localhost:7241/api/rehbber/RehberKaydet
		public IActionResult RehberKaydet([FromBody]RehberDTO rehberDTO)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
            {
				Rehber rehber = _mapper.Map<Rehber>(rehberDTO);
				_context.Rehbers.Add(rehber);
				_context.SaveChanges();
				return Ok("Kayıt İşlemi Başarılı");
			}
            catch (Exception ex)
            {
				return NotFound(ex.Message);
			}
            
        }
        //Rehber işlemi güncellemesi
        [HttpPut("{id}")]//localhost/Rehber/RehberGuncelle/1 (rehberDTO body içerisinde gelecektir.)
        public IActionResult RehberGuncelleme(int id, RehberDTO rehberDto)
        {
            try
            {
				Rehber rehber = _context.Rehbers.Find(id);
				rehber.Adi = rehberDto.Adi;
				rehber.Soyadi = rehberDto.Soyadi;
				rehber.Firma = rehberDto.Firma;
				_context.SaveChanges();
				return Ok("Güncelleme İşlemi Başarılı");
			}
            catch (Exception ex)
            {
				return NotFound(ex.Message);
			}
            

        }
        [HttpDelete("{id}")]//localhost/Rehber/RehberSil/1 
		public IActionResult RehberSil(int id)
        {
            try
            {
				Rehber rehber = _context.Rehbers.Find(id);
				if (rehber == null)
				{
					return NotFound();
				}
				_context.Remove(rehber);
				_context.SaveChanges();
				return Ok("Silme İşlemi Başarılı");
			}
            catch (Exception ex)
            {
				return NotFound(ex.Message);
			}
            
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

					Debug.WriteLine($"Delivery Timestamp:{ result.Timestamp.UtcDateTime}");

				return await Task.FromResult(true);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error occured: {ex.Message}");
			}

			return await Task.FromResult(false);
		}

	}
}


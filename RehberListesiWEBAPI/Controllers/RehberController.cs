using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RehberListesiWEBAPI.Models;
using RehberListesiWEBAPI.Models.Context;
using RehberListesiWEBAPI.Models.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RehberListesiWEBAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class RehberController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

		public RehberController(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
        public IActionResult RehberListesi()
        {
            try
            {
				List<Rehber> rehbers = _context.Rehbers.Include(x => x.IletisimBilgileris).ToList();
				return Ok(rehbers);
			}
            catch (Exception ex)
            {
                return NotFound(ex.Message);
			}
            
        }
        //Rehber kayıt işlemi gerçekleşiyor, sadece rehber bilileri geleceği için RehberDTO kullanıldı.
        [HttpPost]// localhost:7241/api/rehbber
		public IActionResult RehberKaydet([FromBody]RehberDTO rehberDTO)
        {
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
        [HttpPut("{id}")]//localhost/Rehber/id (rehberDTO body içerisinde gelecektir.)
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
        [HttpDelete("{id}")]
        public IActionResult RehberSil(int id)
        {
            try
            {
				Rehber rehber = _context.Rehbers.Find(id);
				_context.Remove(rehber);
				_context.SaveChanges();
				return Ok("Silme İşlemi Başarılı");
			}
            catch (Exception ex)
            {
				return NotFound(ex.Message);
			}
            
        }

    }
}


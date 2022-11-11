using System;
namespace RehberListesiWEBAPI.Models
{
	public class IletisimBilgileri
	{
		public int ID { get; set; }
		public string TelefonNumarasi { get; set; }
		public string EmailAdresi { get; set; }
		public string Adres { get; set; }
		public string Konum { get; set; }

		//Rehber bağlantılı key
		public int RehberID { get; set; }
	}
}


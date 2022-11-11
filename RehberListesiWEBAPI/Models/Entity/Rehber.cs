using System;
namespace RehberListesiWEBAPI.Models
{
	public class Rehber
	{
		public int ID { get; set; }
		public string Adi { get; set; }
		public string Soyadi { get; set; }
		public string Firma { get; set; }

		//İletişim Bilgileri collection ile bağlantı sağlanması
		ICollection<IletisimBilgileri> IletisimBilgileris { get; set; }
	}
}


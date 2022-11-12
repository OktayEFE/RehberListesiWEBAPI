using System;
using System.ComponentModel.DataAnnotations;

namespace RehberListesiWEBAPI.Models
{
	public class Rehber
	{
		[Key]
		public int RehberID { get; set; }
		public string Adi { get; set; }
		public string Soyadi { get; set; }
		public string Firma { get; set; }

		//İletişim Bilgileri collection ile bağlantı sağlanması
		public ICollection<IletisimBilgileri> IletisimBilgileris { get; set; }
	}
}


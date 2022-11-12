using System;
namespace RehberListesiWEBAPI.Models.DTO
{
	public class RehberDTO
	{
		//iletişim bilgilerinin boş geçilmesi durumunda rehber bilgilerinin eklenmesi
		public string Adi { get; set; }
		public string Soyadi { get; set; }
		public string Firma { get; set; }
	}
}


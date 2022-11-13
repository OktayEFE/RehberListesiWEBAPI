using System;
namespace RaporlamaConsumer.Models.Entity
{
	public class Raporlama
	{
		public string Konum { get; set; }
		public int KisiSayisi { get; set; }
		public int TelefonNumarasiSayisi { get; set; }
		public DateTime RaporlamaTalepTarihi { get; set; }
	}
}


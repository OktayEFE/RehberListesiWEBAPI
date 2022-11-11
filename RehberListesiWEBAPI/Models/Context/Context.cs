using System;
using Microsoft.EntityFrameworkCore;

namespace RehberListesiWEBAPI.Models.Context
{
	public class Context : DbContext
	{
		
		public Context(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Rehber> Rehbers { get; set; }
		public DbSet<IletisimBilgileri> IletisimBilgileris { get; set; }
	}
}


using Microsoft.EntityFrameworkCore;
using StoreAppLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppLib.DataAccess
{
	public class ClientContext : DbContext
	{
		public DbSet<Client> Client { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				 Helper.ConnectionString
				 );
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}

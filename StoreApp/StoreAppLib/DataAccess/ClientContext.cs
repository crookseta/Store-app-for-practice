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
				 @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
				 );
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}

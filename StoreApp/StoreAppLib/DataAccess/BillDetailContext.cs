using Microsoft.EntityFrameworkCore;
using StoreAppLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppLib.DataAccess
{
	public class BillDetailContext : DbContext
	{

		public DbSet<Product> Product { get; set; }
		public DbSet<Bill> Bill { get; set; }
		public DbSet<BillDetail> BillDetail { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				 Helper.ConnectionString
				 );
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}

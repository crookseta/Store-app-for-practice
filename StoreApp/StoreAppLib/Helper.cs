using Microsoft.EntityFrameworkCore;
using StoreAppLib.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace StoreAppLib
{
	public static class Helper
	{
		public static string ConnectionString { get; set; } = String.Empty;


		public static async Task<bool> CheckConnection()
		{
			using (var context = new ClientContext())
			{
				return await context.Database.CanConnectAsync();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppLib.Models
{
	public class Product
	{
		[Key]
		public int IdProduct { get; set; }
		public string Name { get; set; } = String.Empty;
		public string Description { get; set; } = String.Empty;
		public decimal Price { get; set; }
	}
}

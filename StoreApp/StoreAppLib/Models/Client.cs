using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppLib.Models
{
	public class Client
	{
		[Key]
		public int IdClient { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Lastname { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		[Column("id_number")]
		public string IdentificationNumber { get; set; } = string.Empty;
		[Column("phone_number")]
		public string PhoneNumber { get; set; } = string.Empty;
	}
}

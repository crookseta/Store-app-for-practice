using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppLib.Models
{
	public class Bill
	{
		[Key]
		public int IdBill { get; set; }
		[Column("bill_number")]
		public string BillNumber { get; set; } = string.Empty;
		public DateTime Date { get; set; }
		public int IdClient { get; set; }
		[ForeignKey("IdClient")]
		public virtual Client? Client { get; set; }

		public DateOnly DateOnly { get => DateOnly.FromDateTime(Date); }
	}
}

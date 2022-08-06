using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreAppLib.Models
{
	[Table("Bill_Detail")]
	public class BillDetail
	{
		[Key, Column("idbill_detail")]
		public int IdBillDetail { get; set; }
		public int IdBill { get; set; }
		[ForeignKey("IdBill")]
		public virtual Bill? Bill { get; set; }
		public int IdProduct { get; set; }
		[ForeignKey("IdProduct")]
		public virtual Product? Product { get; set; }
		public int Quantity { get; set; }
	}
}

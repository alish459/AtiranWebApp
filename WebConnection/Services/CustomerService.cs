using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WebConnection.Services
{
	public class CustomerService
	{
		[Key]
		public int CustomerID { get; set; }
		[Required(ErrorMessage = "لطفا گروه مشتري را انتخاب كنيد")]
		[Display(Name = "گروه مشتري")]
		public int CustomerGroupID { get; set; }
		[MaxLength(50)]
		public string CustomerCode { get; set; }
		[MaxLength(50)]
		[Required(ErrorMessage = "نام مشتري نميتواند خالي باشد")]
		[Display(Name = "نام مشتري")]
		public string CustomerName { get; set; }
		public decimal RealMan { get; set; }
		public decimal AbsMan { get; set; }
		public string Status { get; set; }
		public string Address { get; set; }
		public string Tell1 { get; set; }
		public string Cell { get; set; }
		// Cust Act
		public string Date { get; set; }
		public string UserName { get; set; }
		public string Explain { get; set; }
		public decimal Bed { get; set; }
		public decimal Bes { get; set; }
		public decimal BedSubBes { get; set; }
		public long Ghno { get; set; }
		public int ActID { get; set; }
		public int RowID { get; set; }
		public int MainRowID { get; set; }
	}
}

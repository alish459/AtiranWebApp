using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebConnection.Operation
{
	public class CustomerOperation
	{
		public static List<WebConnection.Services.CustomerService> ReturnCustomerList()
		{
			using (var context = new WebConnection.Model.WebEntities())
			{
				var Res = context.CUSTOMERS.AsNoTracking();
				return (from read in Res
						select new WebConnection.Services.CustomerService
						{
							AbsMan = Math.Abs(read.man),
							Address = read.addre,
							Cell = read.cell,
							CustomerCode = read.code,
							CustomerGroupID = read.group_rdf,
							CustomerID = read.SHMO,
							CustomerName = read.MONAME,
							RealMan = read.man,
							Status = read.man > 0 ? "بدهكار" : read.man < 0 ? "بستانكار" : "--",
							Tell1 = read.tell1,
						}).Take(100).ToList();
			}
		}
		public static WebConnection.Services.CustomerService ReturnCustomerInstance(int Shmo)
		{
			using (var context = new WebConnection.Model.WebEntities())
			{
				var Res = context.CUSTOMERS.Single(a => a.SHMO == Shmo);
				return (new WebConnection.Services.CustomerService
				{
					AbsMan = Math.Abs(Res.man),
					Address = Res.addre,
					Cell = Res.cell,
					CustomerCode = Res.code,
					CustomerGroupID = Res.group_rdf,
					CustomerID = Res.SHMO,
					CustomerName = Res.MONAME,
					RealMan = Res.man,
					Status = Res.man > 0 ? "بدهكار" : Res.man < 0 ? "بستانكار" : "--",
					Tell1 = Res.tell1,
				});
			}
		}
		public static List<WebConnection.Services.CustomerService> ReturnCustomerOperation(int Shmo, string FromDate = "", string ToDate = "")
		{
			using (var context = new WebConnection.Model.WebEntities())
			{
				var FinalResult = new List<WebConnection.Services.CustomerService>();

				Nullable<decimal> actBed = 0;
				Nullable<decimal> actBes = 0;
				string tashkhis = "--";
				IQueryable<WebConnection.Model.cust_act> Result = context.cust_act.Where(a => a.shmo == Shmo).OrderBy(i => i.date);
				if (FromDate != string.Empty)
				{
					Result = Result.Where(a => a.date.CompareTo(FromDate) >= 0);
					actBed = context.cust_act.AsNoTracking().Where(i => i.shmo == Shmo & i.date.CompareTo(FromDate) < 0 & i.isActive != false).Sum(i => (Nullable<decimal>)i.act_bed);
					actBes = context.cust_act.AsNoTracking().Where(i => i.shmo == Shmo & i.date.CompareTo(FromDate) < 0 & i.isActive != false).Sum(i => (Nullable<decimal>)i.act_bes);
					tashkhis = actBed > actBes ? "بد" : actBes > actBed ? "بس" : "--";
					FinalResult.Add(new Services.CustomerService
					{
						Date = "--",
						UserName = "--",
						Explain = "حساب قبلي",
						Bed = actBed ?? 0,
						Bes = actBes ?? 0,
						BedSubBes = (actBed ?? 0) - (actBes ?? 0),
						Status = tashkhis,
						Ghno = 0,
						ActID = 0,
						RowID = 0,
						MainRowID = 0,
					});
				}
				if (ToDate != string.Empty)
				{
					Result = Result.Where(a => a.date.CompareTo(ToDate) <= 0);
				}
				FinalResult.AddRange((from read in Result
									  select new WebConnection.Services.CustomerService
									  {
										  Date = read.date,
										  UserName = read.user_id,
										  Explain = read.act_dis,
										  Bed = read.act_bed,
										  Bes = read.act_bes,
										  BedSubBes = 0,
										  Status = string.Empty,
										  Ghno = read.ghno,
										  ActID = read.act_id,
										  RowID = 0,
										  MainRowID = read.rdf_,
									  }).ToList());
				int j = 0;
				FinalResult = FinalResult.OrderBy(a => a.MainRowID).OrderBy(a => a.Date).ToList();
				FinalResult.ForEach(a => a.RowID = j++);
				FinalResult.ForEach(a => a.BedSubBes = (a.RowID >= 1 ? (FinalResult.Single(b => b.RowID == a.RowID - 1).BedSubBes) : 0) + a.Bed - a.Bes);
				FinalResult.ForEach(a => a.Status = a.BedSubBes > 0 ? "بد" : a.BedSubBes < 0 ? "بس" : "--");
				FinalResult.ForEach(a => a.BedSubBes = Math.Abs(a.BedSubBes));
				return FinalResult;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult InventoryList()
		{
			return View();
		}
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}
		public ActionResult CustomerList()
		{
			var Result = WebConnection.Operation.CustomerOperation.ReturnCustomerList();
			return View(Result);
		}
		public ActionResult CustomerDetails(int ID)
		{
			ViewBag.Message = $"عملكرد مشتري {WebConnection.Operation.CustomerOperation.ReturnCustomerInstance(Shmo: ID).CustomerName}";
			var Result = WebConnection.Operation.CustomerOperation.ReturnCustomerOperation(Shmo : ID);
			return View(Result);
		}
	}
}
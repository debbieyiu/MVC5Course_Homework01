﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerMgmt.Models;

namespace CustomerMgmt.Controllers
{
    public class CustomerDataController : Controller
    {
		private CustomerEntities db = new CustomerEntities();

		// GET: CustomerData
		public ActionResult Index()
        {
			var data = db.客戶資料.OrderByDescending(customer => customer.Id);
			return View(data);
		}

		public ActionResult Create()
		{
			var customer = new 客戶資料();
			return View(customer);
		}

		[HttpPost]
		public ActionResult Create(客戶資料 customer)
		{

			db.客戶資料.Add(customer);
			try
			{
				db.SaveChanges();
			}
			catch (DbEntityValidationException exception)
			{
				foreach (var ex in exception.EntityValidationErrors)
				{
					foreach (var error in ex.ValidationErrors)
					{
						throw new DbEntityValidationException(string.Format("Exception on {0} : {1}", error.PropertyName, error.ErrorMessage));
					}
				}
			}
			return RedirectToAction("Index");

		}

		public ActionResult Edit(int Id)
		{
			var customer = db.客戶資料.FirstOrDefault(x => x.Id.Equals(Id));
			return View(customer);
		}

		public ActionResult Details(int Id)
		{
			var customer = db.客戶資料.FirstOrDefault(x => x.Id.Equals(Id));
			return View(customer);
		}

		public ActionResult Delete(int Id)
		{
			var customer = db.客戶資料.FirstOrDefault(x => x.Id.Equals(Id));
			customer.是否已刪除 = true;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
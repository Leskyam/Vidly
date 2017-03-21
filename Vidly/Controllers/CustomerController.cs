using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View(new Customer().GetCustomers());
        }

        public ActionResult Details(int? id)
        {
            var customer = new Customer().GetCustomers().Find(c => c.Id == id);

            return View(customer);

        }
    }
}
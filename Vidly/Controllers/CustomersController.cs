using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db = ApplicationDbContext.Create();

        protected override void Dispose(bool disposing) => _db?.Dispose();

        // GET: Customer 
        public ActionResult Index()=> View(GetListOfCustomers());

        public ActionResult Edit(int? id)
        {
            var customer = new CustomerFormViewModel()
            {
                Customer = _db.Customers.SingleOrDefault(c => c.Id == id),
                MembershipTypes = _db.MembershipTypes.ToList()
            };
            return View(customer);
        }

        [HttpPost]
        public ActionResult Save(CustomerFormViewModel customerFormViewModel)
        {
            if (customerFormViewModel.Customer.Id == 0)
            {
                _db.Customers.Add(customerFormViewModel.Customer);
            }
            else
            {
                var oldCustomer = _db.Customers.Single(c => c.Id == customerFormViewModel.Customer.Id);
                oldCustomer.Name = customerFormViewModel.Customer.Name;
                oldCustomer.Dob = customerFormViewModel.Customer.Dob;
                oldCustomer.MembershipTypeId = customerFormViewModel.Customer.MembershipTypeId;
                oldCustomer.IsSubscribedToNewsletter = customerFormViewModel.Customer.IsSubscribedToNewsletter;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = _db.Customers.Single(c => c.Id == id);
            _db.Customers.Remove(customer);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private object GetListOfCustomers() => _db.Customers.Include(c => c.MembershipType).ToList();

    }
}
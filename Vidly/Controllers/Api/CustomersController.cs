using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _db = ApplicationDbContext.Create();

        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(CustomerDto.MapToCustomersDto(_db.Customers.ToList()));
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            //return CustomerDto.MapToCustomersDto(new List<Customer>(){(customer)}).Single();
            var customerDto = CustomerDto.MapToCustomersDto(new List<Customer>() {(customer)}).Single();
            return Ok(customerDto);
        }

        // POST /api/customers
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                BadRequest();

            var dbCustomer = _db.Customers.Add(CustomerDto.MapFromCustomerDto(customerDto, new Customer()));
            _db.SaveChanges();
            
            customerDto.Id = dbCustomer.Id;
            return Created(new Uri($"{Request.RequestUri}/{dbCustomer.Id}"),customerDto);
        }

        // PUT /api/customers/
        [System.Web.Mvc.HttpPut]
        public IHttpActionResult PutCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var dbCustomer = _db.Customers.SingleOrDefault(c => c.Id == customerDto.Id);

            if (dbCustomer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            dbCustomer = CustomerDto.MapFromCustomerDto(customerDto, dbCustomer);
            _db.SaveChanges();

            return Ok(CustomerDto.MapToCustomersDto(new List<Customer>() { _db.Customers.SingleOrDefault(c => c.Id == dbCustomer.Id) }).Single());

        }

        // DELETE /api/customers/1
        [System.Web.Mvc.HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var dbCustomer = _db.Customers.SingleOrDefault(c => c.Id == id);
            if (dbCustomer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            _db.Customers.Remove(dbCustomer);
            _db.SaveChanges();

            return Ok(true);

        }



        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
        }
    }
}

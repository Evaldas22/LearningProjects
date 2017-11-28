    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Vidbit.Dtos;
    using Vidbit.Models;

namespace Vidbit.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            // here we need to map all customers to customerDto, so we use select with delegate
            // i think this way is clearer, but not sure it works: 
            // return _contect.Customers.ToList().Select(c => Mapper.Map<Customer, CustomerDto>(c));
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        //GET /api/customers/1
        // instead of return customerDto we will return IHttpActionResult
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return NotFound(); 
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            // here we cannot use select because customer is only one 
            // also Mapper.Map<> return an object
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        // instead of returning customerDto, we will return IHttpActionResult
        // only so the http response status would be not 200, but 201 - created
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            // Here there is no destination object provided in ()
            // so automapper will create new object of type Customer and will return it to customer variable
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            // uri format is like this: /api/customers/10
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            // This will not return an object
            // so if there is no destination object in (), automapper will automatically create new object 
            Mapper.Map(customerDto, customerInDb);            

            _context.SaveChanges();
        }

        //DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}

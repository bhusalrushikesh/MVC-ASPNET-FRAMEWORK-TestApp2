using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TestApp2.Dtos;
using TestApp2.Models;

namespace TestApp2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDtos> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDtos>);
        }

        //GET /api/customers/1
        public CustomerDtos GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer, CustomerDtos>(customer);
        }

        //POST api/customers

        [System.Web.Http.HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        //PUT api/customers/1
        [System.Web.Http.HttpPut]

        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var custInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (custInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            custInDB.Name = customer.Name;
            custInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            custInDB.MembershipTypeId = customer.MembershipTypeId;
            custInDB.BirthDay = customer.BirthDay;

            _context.SaveChanges();

        }


        //DELETE api/customer/1

        [HttpDelete]

        public Customer DeleteCustomer(int id)
        {

            var custInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (custInDb == null)
            {

                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(custInDb);
            _context.SaveChanges();

            return custInDb;


        }







    }
}

using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();

        // Post

        public IHttpActionResult Post(Customer customer)
        {
            // if an empty Customer is passed in
            if (customer == null)
            {
                return BadRequest("Your request body cannot be empty.");
            }

            // if the ModelState is not valid
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);

        }

        // Get

        public IHttpActionResult Get()
        {
            List<Customer> customers = _context.Customers.ToList();

            if (customers.Count != 0)
            {
                return Ok(customers);
            }
            return BadRequest("Your database contains no Customers");
        }


        // Get{id}
        public IHttpActionResult Get(int id)
        {
            // if id is 0
            Customer customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // Put{id}

        // Delete{id}
    }
}

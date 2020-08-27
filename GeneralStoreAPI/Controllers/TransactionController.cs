using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class TransactionController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();

        // Post
        public IHttpActionResult Post(Transaction transaction)
        {
            // if an empty Customer is passed in
            if (transaction == null)
            {
                return BadRequest("Your request body cannot be empty.");
            }

            // if the ModelState is not valid
            if (ModelState.IsValid && transaction.CustomerId != 0 && transaction.ProductSKU != null)
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);

        }

        // Get
        public IHttpActionResult Get()
        {
            List<Transaction> transactions = _context.Transactions.ToList();

            if (transactions.Count != 0)
            {
                return Ok(transactions);
            }
            return BadRequest("Your database contains no Tranasactions... DO SOME WORK");
        }

        // Get{id}
        public IHttpActionResult Get(int id)
        {
            // if id is 0
            Transaction transaction = _context.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        // Put{id}

        // Delete{id}
    }
}

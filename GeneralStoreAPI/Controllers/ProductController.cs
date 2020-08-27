using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class ProductController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();

        // Post

        // Get

        // Get{id}

        // Put{id}

        // Delete{id}

        private string GenerateSku(string productName)
        {
            // Initialize a Random object so we can randomly assign this a number
            Random random = new Random();
​
	        // Get a Random number and turn it into a string
	        var randItemNum = random.Next(0, 1000).ToString();
​
	        // Construct a 3 character string based on the above number. If the number is less than 3 digits, add 0's in front of it to make it 3 digits
	        var itemId = new string('0', 3 - randItemNum.Length) + randItemNum;
​
	        // Create the entire SKU and return it
	        return $"EFA-{productName.Substring(0, 3)}-{itemId}";

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Model;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private static List<Quote> _quotes = new List<Quote>()
        {
            new Quote() { QuoteId = 1, Title = "ABC", Author = "A", Description = "ABCD" },
            new Quote() { QuoteId = 2, Title = "DEF", Author = "D", Description = "DEFG" }
        };


            [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotes;
        }

        [HttpPost]
        public void Post([FromBody]Quote quote)
        {
            _quotes.Add(quote);
        }

        [HttpPut("{id}")]   
        public void Put(int id, [FromBody] Quote quote)
        {
            _quotes[id] = quote;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _quotes.Remove(_quotes[id]);
        }
    }
}
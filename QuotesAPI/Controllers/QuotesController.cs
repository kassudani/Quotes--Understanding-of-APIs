using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Data;
using QuotesAPI.Model;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private QuotesDbCotext _quotesDbContext;

        public QuotesController(QuotesDbCotext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }

        [HttpGet]
        public IEnumerable<Quote> Get()
         {
            return _quotesDbContext.Quotes;
        }

        [HttpGet("{id}", Name = "Get")]
        public Quote Get(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            return quote;
        }

        [HttpPost]
        public void Post([FromBody]Quote quote)
        {
            //_quotes.Add(quote);
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
        }

        [HttpPut("{id}")]   
        public void Put(int id, [FromBody] Quote quote)
        {
            //_quotes[id] = quote;
            var quoteFromDb = _quotesDbContext.Quotes.Find(id);
            quoteFromDb.Title = quote.Title;
            quoteFromDb.Author = quote.Author;
            quoteFromDb.Description = quote.Description;
            _quotesDbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //_quotes.RemoveAt(id);
            //_quotes.Remove(_quotes[id]);
            var quote = _quotesDbContext.Quotes.Find(id);
            _quotesDbContext.Remove((quote));
            _quotesDbContext.SaveChanges();
        }
    }
}
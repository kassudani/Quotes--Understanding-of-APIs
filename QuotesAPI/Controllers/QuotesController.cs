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
        public IActionResult Get(string sort)
        {
            IQueryable<Quote> quotes;
            switch (sort)
            {
                case "asc":
                    quotes = _quotesDbContext.Quotes.OrderBy(q => q.CreatedAt);
                    break;
                case "desc":
                    quotes = _quotesDbContext.Quotes.OrderByDescending(q => q.CreatedAt);
                    break;
                default:
                    quotes = _quotesDbContext.Quotes;
                    break;
            }
            return Ok(quotes);

        }

        [HttpGet("[action]")]
        public IActionResult PagingQuote(int? pageNumber, int? pageSize)
        {
            var quotes = _quotesDbContext.Quotes;

            var pgNumber = pageNumber ?? 1;
            var pgSize = pageSize ?? 3;

            return Ok(quotes.Skip((pgNumber - 1) * pgSize).Take(pgSize));
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult SearchQuote(string type)
        {
            return Ok(_quotesDbContext.Quotes.Where(q => q.Type.StartsWith(type)));
        }



        [HttpGet("{id}", Name = "Get")]
        public Quote Get(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            return quote;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            //_quotes.Add(quote);
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]   
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
            //_quotes[id] = quote;
            var quoteFromDb = _quotesDbContext.Quotes.Find(id);
            if (quoteFromDb == null)
            {
                return NotFound("No data found..");
            }
            quoteFromDb.Title = quote.Title;
            quoteFromDb.Author = quote.Author;
            quoteFromDb.Description = quote.Description;
            _quotesDbContext.SaveChanges();
            return Ok("New Data updated");
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
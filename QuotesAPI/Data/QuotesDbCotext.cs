using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuotesAPI.Model;

namespace QuotesAPI.Data
{
    public class QuotesDbCotext : DbContext
    {
        public QuotesDbCotext(DbContextOptions<QuotesDbCotext> options) : base(options)
        {
            
        }
        public DbSet<Quote> Quotes { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Model
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}

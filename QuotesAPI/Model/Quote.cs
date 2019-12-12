using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuotesAPI.Model
{
    public class Quote
    {
        public int QuoteId { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [StringLength(20)]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }
}

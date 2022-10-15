using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class GetQuotesDto
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? QuoteText { get; set; }
    }
}
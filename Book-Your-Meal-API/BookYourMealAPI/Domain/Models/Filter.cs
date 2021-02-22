using BookYourMealAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class Filter
    {
        public List<string> Typefilters { get; set; }
        public List<string> Categoryfilters { get; set; }

    }
}

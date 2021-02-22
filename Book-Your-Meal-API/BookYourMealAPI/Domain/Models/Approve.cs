using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class Approve
    {
        public string RestaurantName { get; set; }
        public Guid? UserId { get; set; }
        public string RestaurantImageUrl { get; set; }
    }
}

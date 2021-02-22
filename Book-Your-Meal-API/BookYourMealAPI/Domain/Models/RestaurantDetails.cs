using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class RestaurantDetails
    {
        public Guid RestaurantId { get; set; }
        public decimal? Discounts { get; set; }
        public decimal? Rating { get; set; }
        public string RestaurantName { get; set; }
        public int? RestaurantAvailabilityId { get; set; }
        public long? UserMobile { get; set; }
        public string UserLocation { get; set; }
        public string RestaurantImageUrl { get; set; }
        public int? ActiveUserId { get; set; }
    }
}

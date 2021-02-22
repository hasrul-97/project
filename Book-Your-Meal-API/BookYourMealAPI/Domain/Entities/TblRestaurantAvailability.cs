using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblRestaurantAvailability
    {
        public TblRestaurantAvailability()
        {
            TblRestaurantDetails = new HashSet<TblRestaurantDetails>();
        }

        public int RestaurantAvailabilityId { get; set; }
        public string RestaurantAvailability { get; set; }

        public ICollection<TblRestaurantDetails> TblRestaurantDetails { get; set; }
    }
}

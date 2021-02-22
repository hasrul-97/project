using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class BookmarkedRestaurant
    {
        public int FavouriteId { get; set; }
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public decimal? Discounts { get; set; }
        public decimal? Rating { get; set; }
        public int? ActiveUserId { get; set; }
        public string RestaurantImageUrl { get; set; }
    }
}

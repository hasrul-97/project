using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblFavourite
    {
        public int FavouriteId { get; set; }
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }
        public TblRestaurantDetails Restaurant { get; set; }
        public TblUserDetails User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblRestaurantDetails
    {
        public TblRestaurantDetails()
        {
            TblFavourite = new HashSet<TblFavourite>();
            TblItemDetails = new HashSet<TblItemDetails>();
            TblOrder = new HashSet<TblOrder>();
        }

        public Guid RestaurantId { get; set; }
        public Guid? UserId { get; set; }
        public int? ApproveId { get; set; }
        public decimal? Discounts { get; set; }
        public decimal? Rating { get; set; }
        public int? RestaurantAvailabilityId { get; set; }
        public string RestaurantImageUrl { get; set; }

        public TblApprove Approve { get; set; }
        public TblRestaurantAvailability RestaurantAvailability { get; set; }
        public TblUserDetails User { get; set; }
        public ICollection<TblFavourite> TblFavourite { get; set; }
        public ICollection<TblItemDetails> TblItemDetails { get; set; }
        public ICollection<TblOrder> TblOrder { get; set; }
    }
}

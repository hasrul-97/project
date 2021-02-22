using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblOrderDetails = new HashSet<TblOrderDetails>();
            TblReview = new HashSet<TblReview>();
        }

        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public decimal? TotalCost { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime? OrderDtstamp { get; set; }
        public decimal? Rating { get; set; }
        public Guid AddressId { get; set; }

        public TblAddressDetails Address { get; set; }
        public TblRestaurantDetails Restaurant { get; set; }
        public TblUserDetails User { get; set; }
        public ICollection<TblOrderDetails> TblOrderDetails { get; set; }
        public ICollection<TblReview> TblReview { get; set; }
    }
}

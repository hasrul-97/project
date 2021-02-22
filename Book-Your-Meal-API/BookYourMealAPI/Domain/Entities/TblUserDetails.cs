using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblUserDetails
    {
        public TblUserDetails()
        {
            TblAddressDetails = new HashSet<TblAddressDetails>();
            TblApprove = new HashSet<TblApprove>();
            TblFavourite = new HashSet<TblFavourite>();
            TblOrder = new HashSet<TblOrder>();
            TblRestaurantDetails = new HashSet<TblRestaurantDetails>();
            TblReview = new HashSet<TblReview>();
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public long? UserMobile { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? WalletBalance { get; set; }
        public DateTime? SignupDtstamp { get; set; }
        public int RoleId { get; set; }
        public int? ActiveUserId { get; set; }

        public TblActiveUser ActiveUser { get; set; }
        public TblRole Role { get; set; }
        public ICollection<TblAddressDetails> TblAddressDetails { get; set; }
        public ICollection<TblApprove> TblApprove { get; set; }
        public ICollection<TblFavourite> TblFavourite { get; set; }
        public ICollection<TblOrder> TblOrder { get; set; }
        public ICollection<TblRestaurantDetails> TblRestaurantDetails { get; set; }
        public ICollection<TblReview> TblReview { get; set; }
    }
}

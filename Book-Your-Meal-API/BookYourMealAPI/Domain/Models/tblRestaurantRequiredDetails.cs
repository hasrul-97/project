using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class tblRestaurantRequiredDetails
    {
        public string RestaurantName { get; set; }
        public decimal? Discounts { get; set; }
        public decimal? Rating { get; set; }
        public long? UserMobile { get; set; }
        public Guid UserId { get; set; }
        public string Address { get; set; }
        public int? ActiveUserID { get; set; }

    }
}
